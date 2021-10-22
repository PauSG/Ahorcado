using System;
using System.Collections.Generic;
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

namespace Ahorcado
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    
    public class Palabra
    {
        private readonly string[] palabras = { "Pausito", "Josekar", "Deluxeluisiete", "Pipo" };
        private string palabraElegida;

        private void ObtenerPalabraAleatoria()
        {
            Random palabraAleatoria = new Random();
            palabraElegida = palabras[palabraAleatoria.Next(0, 3)];
        }
        public string GetPalabraElegida()
        {
            return palabraElegida;
        }


    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            char[] letras = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ".ToCharArray();
            int numLetra = 0;
            string[] palabras = { "Pausito", "Josekar", "Deluxeluisiete", "Pipo" };
            string palabraElegida;

            for (int fila = 0; fila < 3; fila++)
            {
                for (int columna = 0; columna < 9; columna++, numLetra++)
                {

                    //Creamos y configuramos el botón
                    Button boton = new Button();
                    Grid.SetRow(boton, fila);
                    Grid.SetColumn(boton, columna);
                    boton.Click += Button_Click;
                    boton.Style = (Style)this.Resources["LetrasButtonStyle"];
                    boton.Content = letras[numLetra];
                    boton.Tag = letras[numLetra];

                    letrasGrid.Children.Add(boton);

                }
            }

            palabraElegida = ObtenerPalabraAleatoria(palabras);
            IniciarJuego(palabraElegida);

        }
        private void IniciarJuego()
        {
            for(int i=0; i < Palabra.GetPalabraElegida().Length; i++)
            {
                HuecosTextBlock.Text += "_ ";
            }

        }
        private void ComprobarLetra()
        {
            palabra
        }

        private string ObtenerPalabraAleatoria(string[] palabras)
        {
            
            Random palabraAleatoria = new Random();

            return palabras[palabraAleatoria.Next(0, 3)];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button letraButton = (Button)sender;
            ComprobarLetra();
        }
    }
}
