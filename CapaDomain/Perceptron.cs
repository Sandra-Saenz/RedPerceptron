using System;
using System.IO;

namespace CapaDomain
{
    public class Perceptron
    {
        
        public double GenerarNumeroAleatorio()
        {
            Random random = new Random();

            int[] signo = new int[2];
            signo[0] = -1;
            signo[1] = 1;

            double resultado = 0;
            double[] numeroAletorio = new double[3];
            numeroAletorio[0] = -1;
            numeroAletorio[2] = 1;

            for (int i = 0; i < 5; i++)
            {
                numeroAletorio[1] = random.NextDouble() * signo[random.Next(0, 2)];
                resultado = numeroAletorio[random.Next(0, 3)];
            }
            return (Math.Truncate(resultado * 10000) / 10000);
        }

        public void EntrenamientoPerceptron(int iteraciones, int numEntradas, int numSalidas,
            int numPatrones,  string direccionArchivo)
        {
            int num = 1; double emp = 1; double erms; 
            double rataAprendizaje = 0.1;

            double[] vectorUmbral = new double[numSalidas];
            double[,] matrizPeso = new double[numEntradas, numSalidas];
            int[,] matrizProblema = new int[numPatrones, numEntradas + numSalidas];

            double[] vectorEntrada = new double[numEntradas];
            double[] vectorSalida = new double[numSalidas];

            double[] SalidaRed = new double[numSalidas];
            double[] erroresLineales = new double[numSalidas];
            double[] errorPatron = new double[numPatrones];

            //llenar la matriz problema con el archivo
            StreamReader sreader = new StreamReader(direccionArchivo);
            _ = sreader.ReadLine();
            for (int f = 0; f < numPatrones; f++)
            {
                string lineas = sreader.ReadLine();
                string numeros = lineas.Replace(",", "");
                for (int c = 0; c < numeros.Length; c++)
                {
                   matrizProblema[f, c] = (int)char.GetNumericValue(numeros[c]);
                }
            }
            sreader.Close();

            //crear matriz y vector con nummeros aleatorios
            for (int i = 0; i < numEntradas; i++)
            {
                for (int j = 0; j < numSalidas; j++)
                {
                    matrizPeso[i, j] = GenerarNumeroAleatorio();
                }
            }

            for (int i = 0; i < numSalidas; i++)
            {
                vectorUmbral[i] = GenerarNumeroAleatorio();
            }

            //durara hasta que cumpla su criterio de parada
            bool detener =false;
            while (num <= iteraciones && detener == false)
            {
                //una iteracion pasa por todos los patrones
                for (int i = 0; i < numPatrones; i++)
                {
                    //presentar el vector de entrada y el vector de salida
                    for (int w = 0; w < numSalidas; w++)
                    {
                        if (w < numEntradas)
                        {
                            vectorEntrada[w] = matrizProblema[i, w];
                        }
                        else
                        {
                            vectorSalida[w] = matrizProblema[i, w];
                        }
                    }

                    //calcular las salidas de la red --> Yri
                    double funcionSoma = 0;
                    for (int q = 0; q < numSalidas; q++)
                    {
                        for (int j = 0; j < numEntradas; j++)
                        {
                            funcionSoma = (vectorEntrada[j] * matrizPeso[q, j]) + funcionSoma;
                        }

                        double calcularSalida = (Math.Truncate((funcionSoma - vectorUmbral[q]) * 10000) / 10000);

                        if (calcularSalida < 0)
                        {
                            SalidaRed[q] = 0;
                        }
                        else if (true)
                        {
                            SalidaRed[q] = 1;
                        }
                    }

                    //calcular los errores lineales producidos a la salida
                    for (int ii = 0; ii < numSalidas; ii++)
                    {
                        erroresLineales[ii] = (Math.Truncate((vectorSalida[ii] - SalidaRed[ii]) * 10000) / 10000);
                    }

                    //calcular el error del patron
                    double sumaErrores = 0;
                    for (int a = 0; a < numSalidas; a++)
                    {
                        sumaErrores = erroresLineales[a] + sumaErrores;
                    }

                    errorPatron[i] = (Math.Truncate((sumaErrores / numSalidas) * 10000) / 10000);

                    //modificar pesos
                    for (int z = 0; z < numEntradas; z++)
                    {
                        for (int x = 0; x < numSalidas; x++)
                        {
                            matrizPeso[z, x] = (Math.Truncate((matrizPeso[z, x] + rataAprendizaje * erroresLineales[x] * vectorEntrada[z]) * 10000) / 10000);
                        }
                    }

                    //modificar umbrales 
                    for (int x = 0; x < numSalidas; x++)
                    {
                        vectorUmbral[x] = (Math.Truncate((vectorUmbral[x] + rataAprendizaje * erroresLineales[x] * 1) * 10000) / 10000);
                    }
                }

                //calcular el error del entrenamiento(con este se hace la grafica)
                double sumaErrorPatron = 0;
                for (int l = 0; l < numPatrones; l++)
                {
                    sumaErrorPatron = Math.Abs(errorPatron[l] + sumaErrorPatron);
                }
                erms = (Math.Truncate((sumaErrorPatron / numPatrones) * 10000) / 10000);

                if (erms <= emp)
                {
                    detener = true;
                }
                num++;
            }

            using (StreamWriter writer = new StreamWriter("C:/Users/55YV/Downloads/ArchivosPerceptron/pesosEntrenamiento.txt", false))
            {
                for (int i = 0; i < numEntradas; i++)
                {
                    for (int j = 0; j < numSalidas; j++)
                    {
                        writer.Write(matrizPeso[i, j].ToString() + ";");
                    }
                    writer.Write("\n");
                }
            }

            using (StreamWriter writer = new StreamWriter("C:/Users/55YV/Downloads/ArchivosPerceptron/umbralesEntrenamiento.txt", false))
            {
                for (int i = 0; i < vectorUmbral.Length; i++)
                {
                    writer.Write(vectorUmbral[i].ToString() + ";");
                }
            }
        }

        public void SimularPerceptron()
        {

        }
    }
}
