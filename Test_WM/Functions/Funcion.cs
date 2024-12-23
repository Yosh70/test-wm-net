namespace Test_WM.Functions;

public class Funcion
{
    public static int[,] ObtenerMatriz(int[] terreno)
    {
        int filas = terreno.Max();
        int columnas = terreno.Count();
        int[,] matriz = new int[filas, columnas];

        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                int id = terreno[j] - i;
                matriz[i, j] = id > 0 ? id : 0;
            }
        }

        return matriz;
    }


    public static int ObtenerTotalUnidades(int[,] matriz)
    {
        int filas = matriz.GetLength(0);
        int columnas = matriz.GetLength(1);
        int resultado = 0;

        for (int i = 0; i < filas; i++)
        {
            // Indice del primer numero distinto a 0
            int primerValor = -1;
            for (int j = 0; j < columnas; j++)
            {
                if (matriz[i, j] != 0)
                {
                    primerValor = j;
                    break;
                }
            }

            // Indice del ultimo numero distinto a 0
            int ultimoValor = -1;
            for (int j = columnas - 1; j >= 0; j--)
            {
                if (matriz[i, j] != 0)
                {
                    ultimoValor = j;
                    break;
                }
            }

            int[] list = new int[columnas];
            for (int j = 0; j < columnas; j++)
            {
                list[j] = matriz[i, j];
            }

            if (primerValor != -1 && ultimoValor != -1)
            {
                int[] rangoValores = new int[ultimoValor - primerValor + 1];
                Array.Copy(list, primerValor, rangoValores, 0, rangoValores.Length);

                resultado += rangoValores.Count(x => x == 0);

                //foreach (int num in rangoValores)
                //{
                //    Console.Write(num + "-");
                //}
            }

            Console.WriteLine("\n");
        }

        return resultado;
    }

    public static int[] ObtenerUnidadesTerreno(int[,] matriz)
    {
        int filas = matriz.GetLength(0);
        int columnas = matriz.GetLength(1);
        int[] unidades = new int[columnas];

        for (int i = 0; i < filas; i++)
        {
            //Indice del primer numero distinto a 0
            int primerValor = -1;
            for (int j = 0; j < columnas; j++)
            {
                if (matriz[i, j] != 0)
                {
                    primerValor = j;
                    break;
                }
            }

            // Indice del ultimo numero distinto a 0
            int ultimoValor = -1;
            for (int j = columnas - 1; j >= 0; j--)
            {
                if (matriz[i, j] != 0)
                {
                    ultimoValor = j;
                    break;
                }
            }

            for (int j = 0; j < columnas; j++)
            {
                if (j > primerValor && j < ultimoValor && matriz[i, j] == 0)
                {
                    unidades[j] = i + 1;
                }
            }


        }

        return unidades;
    }



}
