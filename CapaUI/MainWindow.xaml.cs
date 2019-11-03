using CapaDomain;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CapaUI
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly Perceptron perceptron = new Perceptron();

        public MainWindow()
        {
            InitializeComponent();
        }

        private int ObtenerNIteraciones()
        {
            return Convert.ToInt32(txtIteracion.Text);

        }

        private void CargarSolucionEnDGV()
        {
            lbTablaSolucion.Items.Clear();
            string dirPeso = "C:/Users/55YV/Downloads/ArchivosPerceptron/pesosEntrenamiento.txt";
            string dirUmbral = "C:/Users/55YV/Downloads/ArchivosPerceptron/umbralesEntrenamiento.txt";

            try
            {
                StreamReader import = new StreamReader(dirPeso);
                lbTablaSolucion.Items.Add("TABLA SOLUCION DEL ENTRENAMIENTO");
                lbTablaSolucion.Items.Add("Matriz de pesos final");
                while (import.Peek() >= 0)
                {
                    string linea = import.ReadLine();
                    string numeros = linea.Replace(";", "   ");
                    lbTablaSolucion.Items.Add(Convert.ToString(numeros, CultureInfo.CurrentCulture));
                }

                StreamReader importU = new StreamReader(dirUmbral);
                lbTablaSolucion.Items.Add("Vector de umbrales final");
                while (importU.Peek() >= 0)
                {
                    string lineas = importU.ReadLine();
                    string numero = lineas.Replace(";", "   ");
                    lbTablaSolucion.Items.Add(Convert.ToString(numero, CultureInfo.CurrentCulture));
                }
                import.Close();
                importU.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message, CultureInfo.CurrentCulture));
                return;
            }

        }

        private void RealizarEntrenamiento()
        {
            int entrada = 0, salida = 0; string direccion = txtDireccionArchivo.Text;

            StreamReader sr = new StreamReader(direccion);
            int numeroFilas = File.ReadAllLines(direccion).Length;

            for (int f = 0; f < 1; f++)
            {
                string linea = sr.ReadLine();

                for (int c = 0; c < linea.Length; c++)
                {
                    if (Convert.ToString(linea[c], CultureInfo.CurrentCulture) == "x" || Convert.ToString(linea[c], CultureInfo.CurrentCulture) == "X")
                    {
                        entrada++;
                    }
                    else if (Convert.ToString(linea[c], CultureInfo.CurrentCulture) == "y" || Convert.ToString(linea[c], CultureInfo.CurrentCulture) == "Y")
                    {
                        salida++;
                    }
                }
            }
            sr.Close();

            int numeroIteraciones = ObtenerNIteraciones();
            int numeroEntradas = entrada;
            int numeroSalidas = salida;
            int numeroPatrones = numeroFilas - 1;

            //llamar al metodo y pasarle los parametros
            perceptron.EntrenamientoPerceptron(numeroIteraciones, numeroEntradas, numeroSalidas, numeroPatrones, direccion);

        }

        private void Grafica()
        {

        }

            private void BtnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtIteracion.Text = "";
            txtDireccionArchivo.Text = "";
            lbTablaSolucion.Items.Clear();
            lbTablaProblema.Items.Clear();
        }

        private void BtnExaminar_Click(object sender, RoutedEventArgs e)
        {
            this.lbTablaProblema.Items.Clear();
            OpenFileDialog open = new OpenFileDialog();
            //open.Filter = "Archivo txt (*.txt)|*.txt|All(*,*)|*,*";
            try
            {
                open.ShowDialog();
                txtDireccionArchivo.Text = open.FileName;
                StreamReader import = new StreamReader(Convert.ToString(txtDireccionArchivo.Text, CultureInfo.CurrentCulture));
                lbTablaProblema.Items.Add("TABLA DEL PROBLEMA");
                while (import.Peek() >= 0)
                {
                    string linea = import.ReadLine();
                    string numeros = linea.Replace(",", "   ");
                    lbTablaProblema.Items.Add(Convert.ToString(numeros, CultureInfo.CurrentCulture));
                }
                import.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message, CultureInfo.CurrentCulture));
                return;
            }
        }

        private void BtnEntrenar_Click(object sender, RoutedEventArgs e)
        {
            RealizarEntrenamiento();
            Grafica();
            MessageBox.Show("Entrenamiento realizado.");
            CargarSolucionEnDGV();
        }

        private void BtnSimular_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
