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
            return resultado;
        }

        public void EntrenamientoPerceptron(int iteraciones, int numEntradas, int numSalidas,
            int numPatrones,  string direccionArchivo, double rata, double ErrorMax)
        {
            int num = 1; double emp = ErrorMax; double erms; 
            double rataAprendizaje = rata;

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
                            funcionSoma = (vectorEntrada[j] * matrizPeso[j, q]) + funcionSoma;
                        }

                        double calcularSalida = (funcionSoma - vectorUmbral[q]);

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
                        erroresLineales[ii] = (vectorSalida[ii] - SalidaRed[ii]);
                    }

                    //calcular el error del patron
                    double sumaErrores = 0;
                    for (int a = 0; a < numSalidas; a++)
                    {
                        sumaErrores = erroresLineales[a] + sumaErrores;
                    }

                    errorPatron[i] = (sumaErrores / numSalidas);

                    //modificar pesos
                    for (int z = 0; z < numEntradas; z++)
                    {
                        for (int x = 0; x < numSalidas; x++)
                        {
                            matrizPeso[z, x] = (matrizPeso[z, x] + rataAprendizaje * erroresLineales[x] * vectorEntrada[z]);
                        }
                    }

                    //modificar umbrales 
                    for (int x = 0; x < numSalidas; x++)
                    {
                        vectorUmbral[x] = (vectorUmbral[x] + rataAprendizaje * erroresLineales[x] * 1);
                    }
                }

                //calcular el error del entrenamiento(con este se hace la grafica)
                double sumaErrorPatron = 0;
                for (int l = 0; l < numPatrones; l++)
                {
                    sumaErrorPatron = Math.Abs(errorPatron[l] + sumaErrorPatron);
                }
                erms = (sumaErrorPatron / numPatrones);

                if (erms <= emp)
                {
                    detener = true;
                }
                num++;
            }

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
        }

        public string SimularPerceptron(string patron)
        {
            string dirPesos = "C:/Users/55YV/Downloads/redes/ArchivosPerceptron/pesosEntrenamiento.txt";
            string dirUmbrales = "C:/Users/55YV/Downloads/redes/ArchivosPerceptron/umbralesEntrenamiento.txt";
            string direccion = "C:/Users/55YV/Downloads/redes/ArchivosPerceptron/problema.csv";

            int numEntradas = 0, numSalidas = 0;

            StreamReader sr = new StreamReader(direccion);
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

            double[] vectorUmbral = new double[numSalidas];
            double[,] matrizPeso = new double[numEntradas, numSalidas];
            double[] SalidaRed = new double[numSalidas];
            _ = new Random();


            // guardar los valores del archivo en matrizPeso 
            int numeroFilas2 = File.ReadAllLines(dirPesos).Length;
            StreamReader sreader = new StreamReader(dirPesos);
            for (int f = 0; f < numeroFilas2; f++)
            {
                string linea = sreader.ReadLine();
                string[] numero = linea.Split(';');
                //string numeros = lineas.Replace(";", "");
                for (int c = 0; c < numero.Length - 1; c++)
                {
                    matrizPeso[f, c] = Convert.ToDouble(numero[c]);
                }
            }
            sreader.Close();

            // guardar los valores del archivo en vector umbral
            StreamReader reader = new StreamReader(dirUmbrales);
            string lineas = reader.ReadLine();
            string[] numeros = lineas.Split(';');
            for (int f = 0; f < numeros.Length - 1; f++)
            {
                vectorUmbral[f] = Convert.ToDouble(numeros[f]);
            }
            sreader.Close();

            double calcularSalida;
            string[] numeroPatron = patron.Split(';');
            double[] patronSimulado = new double[numEntradas];

            //presentar el vector de entrada y el vector de salida
            for (int w = 0; w < numEntradas; w++)
            {
                patronSimulado[w] = Convert.ToDouble(numeroPatron[w]);
                Console.WriteLine(patronSimulado[w]);
            }

            //calcular las salidas de la red --> Yri
            double funcionSoma = 0;
            for (int q = 0; q < numEntradas; q++)
            {
                for (int j = 0; j < numSalidas; j++)
                {
                    funcionSoma = (patronSimulado[q] * matrizPeso[q, j]) + funcionSoma;
                }
                calcularSalida = (funcionSoma - vectorUmbral[q]);

                if (calcularSalida < 0)
                {
                    SalidaRed[q] = 0;
                }
                else
                {
                    SalidaRed[q] = 1;
                }
                funcionSoma = 0;
            }

            string resultado = "";
            for (int i = 0; i < numSalidas; i++)
            {
               resultado= resultado + " " + Convert.ToString(SalidaRed[i]) ;
            }

            return resultado;
        }
    }
}
