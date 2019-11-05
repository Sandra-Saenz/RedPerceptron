using System;
using System.IO;

namespace Ejemplos
{
    class Program
    {
        static void Main(string[] args)
        {

            Entrenamiento(3, "C:/Users/55YV/Downloads/redes/ArchivosPerceptron/problema.csv");
            Simulacion("1;0");

        }

        private static void Entrenamiento(int iteraciones, string direccionArchivo)
        {
            int numEntradas = 0, numSalidas = 0;
            string direccion = direccionArchivo;

            StreamReader sr = new StreamReader(direccion);
            int numeroFilas = File.ReadAllLines(direccion).Length;
            int Patrones = numeroFilas - 1;

            for (int f = 0; f < 1; f++)
            {
                string linea = sr.ReadLine();
                for (int c = 0; c < linea.Length; c++)
                {
                    if (Convert.ToString(linea[c]) == "x" || Convert.ToString(linea[c]) == "X")
                    {
                        numEntradas++;
                    }
                    else if (Convert.ToString(linea[c]) == "y" || Convert.ToString(linea[c]) == "Y")
                    {
                        numSalidas++;
                    }
                }
            }
            sr.Close();

            int num = 1; double emp = 1; double erms;
            double rataAprendizaje = 0.1;

            double[] vectorUmbral = new double[numSalidas];
            double[,] matrizPeso = new double[numEntradas, numSalidas];
            int[,] matrizProblema = new int[Patrones, numEntradas + numSalidas];

            double[] vectorEntrada = new double[numEntradas];
            double[] vectorSalida = new double[numSalidas];

            double[] SalidaRed = new double[numSalidas];
            double[] erroresLineales = new double[numSalidas];
            double[] errorPatron = new double[Patrones];
            _ = new Random();

            // guardar los valores del archivo en matrizProblema
            StreamReader sreader = new StreamReader(direccion);
            _ = sreader.ReadLine();
            for (int f = 0; f < Patrones; f++)
            {
                string lineas = sreader.ReadLine();
                string numeros = lineas.Replace(",", "");
                for (int c = 0; c < numeros.Length; c++)
                {
                    if (Convert.ToString(numeros[c]) != ",")
                    {
                        matrizProblema[f, c] = (int)char.GetNumericValue(numeros[c]);
                    }
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


            //mostrar pesos
            Console.WriteLine("matriz peso");
            for (int z = 0; z < numEntradas; z++)
            {
                for (int x = 0; x < numSalidas; x++)
                {
                    Console.Write(matrizPeso[z, x] + " ");
                }
                Console.Write("\n");
            }
            //mostrar umbrales 
            Console.WriteLine("umbral salida");
            for (int x = 0; x < numSalidas; x++)
            {
                Console.Write(vectorUmbral[x] + " ");
            }
            Console.WriteLine("\n");


            bool detener = false;
            while (num <= iteraciones && detener == false)
            {
                Console.WriteLine("iteracion n°: " + num);
                //una iteracion es pasar por todos los patrones
                for (int i = 0; i < Patrones; i++)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("Patron n°: " + i);

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
                            funcionSoma = (vectorEntrada[j] * matrizPeso[j, q]) + funcionSoma;
                        }

                        double calcularSalida = (Math.Truncate((funcionSoma - vectorUmbral[q]) * 10000) / 10000);
                        Console.WriteLine("salida de la red: " + calcularSalida);

                        if (calcularSalida < 0)
                        {
                            SalidaRed[q] = 0;
                        }
                        else if (true)
                        {
                            SalidaRed[q] = 1;
                        }
                        Console.WriteLine("salida de la red con la funcion activacion: " + SalidaRed[q]);
                    }

                    //calcular los errores lineales producidos a la salida
                    for (int ii = 0; ii < numSalidas; ii++)
                    {
                        erroresLineales[ii] = (Math.Truncate((vectorSalida[ii] - SalidaRed[ii]) * 10000) / 10000);
                        Console.WriteLine("error lineal " + ii + ": " + erroresLineales[ii]);
                    }

                    //calcular el error del patron
                    double sumaErrores = 0;
                    for (int a = 0; a < numSalidas; a++)
                    {
                        sumaErrores = erroresLineales[a] + sumaErrores;
                    }

                    errorPatron[i] = (Math.Truncate((sumaErrores / numSalidas) * 10000) / 10000);
                    Console.WriteLine("error del patron: " + errorPatron[i]);

                    //modificar pesos
                    Console.Write("\n");
                    Console.WriteLine("nueva matriz peso");

                    for (int z = 0; z < numEntradas; z++)
                    {
                        for (int x = 0; x < numSalidas; x++)
                        {
                            matrizPeso[z, x] = (Math.Truncate((matrizPeso[z, x] + rataAprendizaje * erroresLineales[x] * vectorEntrada[z]) * 10000) / 10000);
                            Console.Write(matrizPeso[z, x] + " ");
                        }
                        Console.Write("\n");
                    }

                    //modificar umbrales 
                    Console.Write("\n");
                    Console.WriteLine("nuevo umbral salida");
                    for (int x = 0; x < numSalidas; x++)
                    {
                        vectorUmbral[x] = (Math.Truncate((vectorUmbral[x] + rataAprendizaje * erroresLineales[x] * 1) * 10000) / 10000);
                        Console.Write(vectorUmbral[x] + " ");
                    }
                }
                Console.Write("\n");

                //calcular el error del entrenamiento (con este se hace la grafica)
                double sumaErrorPatron = 0;
                for (int l = 0; l < Patrones; l++)
                {
                    sumaErrorPatron = Math.Abs(errorPatron[l] + sumaErrorPatron);
                }

                erms = (Math.Truncate((sumaErrorPatron / Patrones) * 10000) / 10000);
                Console.Write("\n");
                Console.WriteLine("error entrenamiento " + erms);

                if (erms <= emp)
                {
                    detener = true;
                }
                num++;
            }
            Console.Write("\n");
            Console.WriteLine("Entrenamiento finalizado.");

            using (StreamWriter writer = new StreamWriter("C:/Users/55YV/Downloads/redes/ArchivosPerceptron/pesosEntrenamiento.txt", false))
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

            using (StreamWriter writer = new StreamWriter("C:/Users/55YV/Downloads/redes/ArchivosPerceptron/umbralesEntrenamiento.txt", false))
            {
                for (int i = 0; i < vectorUmbral.Length; i++)
                {
                    writer.Write(vectorUmbral[i].ToString() + ";");
                }
            }

            Console.Write("\n");
            Console.WriteLine("Pesos y umbrales guardados");

            Console.ReadKey();
        }

        //arreglar el numero aleatorio. para que no se pase de -1
        static double GenerarNumeroAleatorio()
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

        private static void Simulacion(string patron)
        {
            string dirPesos = "C:/Users/55YV/Downloads/ArchivosPerceptron/pesosEntrenamiento.txt";
            string dirUmbrales = "C:/Users/55YV/Downloads/ArchivosPerceptron/umbralesEntrenamiento.txt";

            int numEntradas = 0, numSalidas = 0;

            StreamReader sr = new StreamReader(dirPesos);
            int numeroFilas = File.ReadAllLines(dirPesos).Length;
            int Patrones = numeroFilas;


            int num = 1; double emp = 1; double erms;
            double rataAprendizaje = 0.1;

            double[] vectorUmbral = new double[numSalidas];
            double[,] matrizPeso = new double[numEntradas, numSalidas];

            // guardar los valores del archivo en matrizPeso y vector umbral
            StreamReader sreader = new StreamReader(dirPesos);
            for (int f = 0; f < Patrones; f++)
            {
                string lineas = sreader.ReadLine();
                string numeros = lineas.Replace(";", "");
                for (int c = 0; c < numeros.Length; c++)
                {
                    if (Convert.ToString(numeros[c]) != ";")
                    {
                        matrizPeso[f, c] = (int)char.GetNumericValue(numeros[c]);
                    }
                }
            }
            sreader.Close();

            // guardar los valores del archivo en vector umbral
            StreamReader reader = new StreamReader(dirUmbrales);
            _ = sreader.ReadLine();
            for (int f = 0; f < 1; f++)
            {
                string lineas = reader.ReadLine();
                string numeros = lineas.Replace(";", "");
                    if (Convert.ToString(numeros[f]) != ";")
                    {
                        vectorUmbral[f] = (int)char.GetNumericValue(numeros[f]);
                    }
            }
            sreader.Close();
        }
    }
}
