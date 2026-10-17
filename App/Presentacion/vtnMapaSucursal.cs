using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Entidad;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace Presentacion
{
    /// <summary>
    /// Ventana con el mapa de las sucursales. Tiene dos usos:
    /// ver todas las sucursales (<see cref="Mostrar"/>) y elegir la ubicación de una (<see cref="ElegirUbicacion"/>).
    /// </summary>
    public partial class VtnMapaSucursal : FormularioBase
    {
        // Centro de Guayaquil: posición inicial cuando no hay ninguna coordenada
        private static readonly PointLatLng CentroPorDefecto = new PointLatLng(-2.19616, -79.88621);
        private const int ZoomDetalle = 16;
        private const string IdCapaSucursales = "sucursales";

        private readonly bool modoElegir;
        private readonly GMapOverlay capaSucursales = new GMapOverlay(IdCapaSucursales);
        private readonly GMapOverlay capaSeleccion = new GMapOverlay("seleccion");
        private readonly PointLatLng? posicionInicial;
        private GMarkerGoogle marcadorElegido;
        private Point inicioClic;

        /// <summary>
        /// Ubicación marcada por el usuario en el modo de elegir.
        /// </summary>
        private PointLatLng? ubicacionElegida;

        /// <summary>
        /// Constructor usado por el diseñador.
        /// </summary>
        public VtnMapaSucursal() : this(Enumerable.Empty<Sucursal>(), null, false)
        {
        }

        private VtnMapaSucursal(IEnumerable<Sucursal> sucursales, PointLatLng? posicion, bool elegir)
        {
            InitializeComponent();
            modoElegir = elegir;
            posicionInicial = posicion;

            mapa.MapProvider = GMapProviders.GoogleMap;
            mapa.DragButton = MouseButtons.Left;
            mapa.Position = posicion ?? CentroPorDefecto;
            mapa.Overlays.Add(capaSucursales);
            mapa.Overlays.Add(capaSeleccion);

            foreach (Sucursal sucursal in sucursales.Where(s => s.Latitud.HasValue && s.Longitud.HasValue))
            {
                capaSucursales.Markers.Add(CrearMarcador(sucursal));
            }

            if (modoElegir)
            {
                Text = "Elegir ubicación";
                lblTitulo.Text = "Elegir ubicación de la sucursal";
                lblIndicacion.Text = "Haz clic donde está la sucursal. Arrastra para moverte y usa la rueda del mouse para acercarte.";
                lblCoordenadas.Text = "Aún no has marcado una ubicación.";
                if (posicion.HasValue)
                {
                    MarcarUbicacion(posicion.Value);
                }
            }
            else
            {
                lblIndicacion.Text = "Verde: abierta · Rojo: cerrada. Pasa el mouse sobre un marcador para ver sus datos.";
                lblCoordenadas.Text = $"{capaSucursales.Markers.Count} sucursales en el mapa";
                btnUsarUbicacion.Visible = false;
                btnCancelar.Text = "Cerrar";
                btnCancelar.Left = btnUsarUbicacion.Right - btnCancelar.Width;
                AcceptButton = null;
            }
        }

        /// <summary>
        /// Muestra todas las sucursales en el mapa, centrado en la seleccionada si hay una.
        /// </summary>
        public static void Mostrar(IWin32Window propietario, IEnumerable<Sucursal> sucursales, Sucursal seleccionada)
        {
            PointLatLng? centro = seleccionada?.Latitud != null && seleccionada.Longitud != null
                ? new PointLatLng(seleccionada.Latitud.Value, seleccionada.Longitud.Value)
                : (PointLatLng?)null;

            using (var ventana = new VtnMapaSucursal(sucursales, centro, false))
            {
                ventana.ShowDialog(propietario);
            }
        }

        /// <summary>
        /// Abre el mapa para que el usuario marque la ubicación de una sucursal.
        /// </summary>
        /// <param name="propietario">Ventana sobre la que se abre el mapa.</param>
        /// <param name="sucursales">Otras sucursales, que se muestran como referencia.</param>
        /// <param name="actual">Ubicación actual de la sucursal, si ya tiene una.</param>
        /// <param name="elegida">La ubicación marcada, si el usuario la confirmó.</param>
        /// <returns>true si el usuario confirmó una ubicación.</returns>
        public static bool ElegirUbicacion(IWin32Window propietario, IEnumerable<Sucursal> sucursales, PointLatLng? actual, out PointLatLng elegida)
        {
            using (var ventana = new VtnMapaSucursal(sucursales, actual, true))
            {
                PointLatLng? marcada = ventana.ShowDialog(propietario) == DialogResult.OK ? ventana.UbicacionMarcada() : null;
                elegida = marcada ?? default;
                return marcada.HasValue;
            }
        }

        private PointLatLng? UbicacionMarcada() => ubicacionElegida;

        private void VtnMapaSucursal_Shown(object sender, EventArgs e)
        {
            if (posicionInicial.HasValue)
            {
                mapa.Zoom = ZoomDetalle;
            }
            else if (capaSucursales.Markers.Count > 0)
            {
                // Encuadra todas las sucursales
                mapa.ZoomAndCenterMarkers(IdCapaSucursales);
                if (mapa.Zoom > ZoomDetalle)
                {
                    mapa.Zoom = ZoomDetalle;
                }
            }
        }

        private void Mapa_MouseDown(object sender, MouseEventArgs e)
        {
            inicioClic = e.Location;
        }

        private void Mapa_MouseUp(object sender, MouseEventArgs e)
        {
            // Un clic marca la ubicación; si el mouse se movió, el usuario estaba arrastrando el mapa
            bool fueArrastre = Math.Abs(e.X - inicioClic.X) > 4 || Math.Abs(e.Y - inicioClic.Y) > 4;
            if (modoElegir && e.Button == MouseButtons.Left && !fueArrastre)
            {
                MarcarUbicacion(mapa.FromLocalToLatLng(e.X, e.Y));
            }
        }

        private void MarcarUbicacion(PointLatLng punto)
        {
            punto = new PointLatLng(Math.Round(punto.Lat, 6), Math.Round(punto.Lng, 6));
            if (marcadorElegido == null)
            {
                marcadorElegido = new GMarkerGoogle(punto, GMarkerGoogleType.red_dot);
                capaSeleccion.Markers.Add(marcadorElegido);
            }
            else
            {
                marcadorElegido.Position = punto;
            }

            ubicacionElegida = punto;
            lblCoordenadas.Text = $"Latitud {Coordenada.Formatear(punto.Lat)}   ·   Longitud {Coordenada.Formatear(punto.Lng)}";
            btnUsarUbicacion.Enabled = true;
        }

        private void BtnUsarUbicacion_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private GMarkerGoogle CrearMarcador(Sucursal sucursal)
        {
            var posicion = new PointLatLng(sucursal.Latitud.Value, sucursal.Longitud.Value);
            // Al elegir una ubicación, las demás sucursales se muestran pequeñas como referencia
            GMarkerGoogleType tipo = modoElegir ? GMarkerGoogleType.gray_small
                : sucursal.Estado ? GMarkerGoogleType.green_dot : GMarkerGoogleType.red_dot;

            var marcador = new GMarkerGoogle(posicion, tipo)
            {
                ToolTipText = $"{sucursal.Nombre}\n{sucursal.Direccion}\n{sucursal.Ciudad} · {(sucursal.Estado ? "Abierta" : "Cerrada")}"
            };
            marcador.ToolTip.Fill = Brushes.White;
            marcador.ToolTip.Foreground = new SolidBrush(Tema.Texto);
            marcador.ToolTip.Stroke = new Pen(Tema.Borde);
            marcador.ToolTip.Font = new Font("Segoe UI", 9F);
            marcador.ToolTip.TextPadding = new Size(12, 8);
            return marcador;
        }
    }
}
