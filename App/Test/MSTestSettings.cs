// Las pruebas no usan base de datos: la capa de datos se reemplaza por mocks (Moq).
// Se paralelizan por clase porque CN_Usuario guarda los intentos de login en un campo estático
// y sus pruebas deben ejecutarse en serie dentro de la misma clase.
[assembly: Parallelize(Scope = ExecutionScope.ClassLevel)]
