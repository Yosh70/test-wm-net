using Test_WM.Functions;

int[] terreno = { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };

int[,] matriz = Funcion.ObtenerMatriz(terreno);
int[] unidadesTerreno = Funcion.ObtenerUnidadesTerreno(matriz);
int unidades = Funcion.ObtenerTotalUnidades(matriz);

Console.ReadLine();



