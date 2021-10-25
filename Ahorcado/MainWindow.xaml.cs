using System;
using System.Collections;
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

    public partial class MainWindow : Window
    {
        //private readonly string[] palabras = { "Pausito", "Josekar", "Deluxeluisiete", "Pipo" };
        private readonly string[] palabras = { "pipo", "pipo", "pipo", "pipo" };
        private string palabraElegida;
        public MainWindow()
        {
            InitializeComponent();

            char[] letras = "abcdefghijklmnñopqrstuvwxyz".ToCharArray();
            int numLetra = 0;

            for (int fila = 0; fila < 3; fila++)
            {
                for (int columna = 0; columna < 9; columna++, numLetra++)
                {

                    //Creamos y configuramos el botón
                    Button boton = new Button();
                    Grid.SetRow(boton, fila);
                    Grid.SetColumn(boton, columna);
                    //boton.Click += LetraButton_Click;
                    boton.Style = (Style)this.Resources["LetrasButtonStyle"];
                    boton.Content = letras[numLetra];
                    boton.Tag = letras[numLetra];

                    letrasGrid.Children.Add(boton);

                }
            }

            palabraElegida = ObtenerPalabraAleatoria();
            for (int i = 0; i < palabraElegida.Length; i++)
            {
                TextBlock tb = new TextBlock();
                tb.Text = palabraElegida[i].ToString();
                tb.Visibility = Visibility.Hidden;

                Viewbox vb = new Viewbox();
                vb.Child = tb;

                Border b = new Border();
                b.BorderThickness = new Thickness(0, 0, 0, 3);
                b.BorderBrush = Brushes.Black;
                b.Margin = new Thickness(10);
                b.Width = 30;
                b.Child = vb;

                huecoStackpanel.Children.Add(b);

            }

        }
        public string ObtenerPalabraAleatoria()
        {
            Random palabraAleatoria = new Random();
            return palabras[palabraAleatoria.Next(0, 3)];
        }
        private void ComprobarLetra(char letra)
        {
            IList huecoStackpanellist = huecoStackpanel.Children;

            for (int i = 0; i < huecoStackpanel.Children.Count; i++)
            {
                Viewbox viewbox = (Viewbox)huecoStackpanellist[i];
                TextBlock textblock = viewbox.Child as TextBlock;
                if (textblock.Text.Equals(letra))
                {
                    textblock.Visibility = Visibility.Visible;
                }


            }
        }

        private void LetraButton_Click(object sender, RoutedEventArgs e)
        {
            Button letraButton = (Button)sender;
            char letra = (char)letraButton.Content;
            ComprobarLetra(letra);
            letraButton.IsEnabled = false;
        }

        private void NuevaPartidaButton_Click(object sender, RoutedEventArgs e)
        {
            palabraElegida = ObtenerPalabraAleatoria();
            for (int i = 0; i < palabraElegida.Length; i++)
            {
                TextBlock tb = new TextBlock();
                tb.Text = palabraElegida[i].ToString();
                tb.Visibility = Visibility.Hidden;

                Viewbox vb = new Viewbox();
                vb.Child = tb;

                Border b = new Border();
                b.BorderThickness = new Thickness(0, 0, 0, 3);
                b.BorderBrush = Brushes.Black;
                b.Margin = new Thickness(10);
                b.Width = 30;
                b.Child = vb;

                huecoStackpanel.Children.Add(b);

            }
            for (int i = 0; i < letrasGrid.Children.Count; i++)
            {
                Button boton = (Button)letrasGrid.Children[i];
                boton.IsEnabled = true;
            }
        }
    }
}
