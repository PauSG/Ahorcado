﻿using System;
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
        private readonly string[] palabras = { "Pausito", "Josekar", "Deluxeluisiete", "Pipo", "Interfaces", "Electrodomestico", "StackPanel", "Hipopotamo" };
        private string palabraElegida;
        int fallos, aciertos;
        public MainWindow()
        {
            InitializeComponent();

            char[] letras = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ".ToCharArray();
            int numLetra = 0;

            for (int fila = 0; fila < 3; fila++)
            {
                for (int columna = 0; columna < 9; columna++, numLetra++)
                {

                    //Creamos y configuramos el botón
                    Button boton = new Button();
                    Grid.SetRow(boton, fila);
                    Grid.SetColumn(boton, columna);
                    boton.Click += LetraButton_Click;
                    boton.Style = (Style)this.Resources["LetrasButtonStyle"];
                    boton.Content = letras[numLetra];
                    boton.Tag = letras[numLetra];

                    letrasGrid.Children.Add(boton);

                }
            }

            IniciarJuego();
            
        }
        public string ObtenerPalabraAleatoria()
        {
            Random palabraAleatoria = new Random();
            return palabras[palabraAleatoria.Next(0, 3)];
        }
        private void ComprobarLetra(string letra)
        {
            bool existe = false;
            for (int i = 0; i < huecoStackpanel.Children.Count; i++)
            {
                Border b = (Border)huecoStackpanel.Children[i];
                Viewbox vb = b.Child as Viewbox;
                TextBlock tb = vb.Child as TextBlock;
                if (tb.Text.Equals(letra.ToLower()) || tb.Text.Equals(letra.ToUpper()))
                {
                    tb.Visibility = Visibility.Visible;
                    existe = true;
                    aciertos++;
                    if (aciertos == huecoStackpanel.Children.Count) MessageBox.Show("Has Acertado!!", "Resultado");
                }
            }
            if (!existe)
            {
                fallos++;
                cambiarImagen(fallos);
                if (fallos == 10)
                {
                    AcabarJuego();
                    MessageBox.Show("Has Fallado demasiadas veces, intentalo de nuevo", "RESULTADO");
                }
            }  
        }

        private void cambiarImagen(int fallos)
        {
            ahorcadoImagen.Source = new BitmapImage(new Uri(@".\assets\" + fallos + ".jpg", UriKind.Relative));
        }

        private void LetraButton_Click(object sender, RoutedEventArgs e)
        {
            Button letraButton = (Button)sender;
            char letra = (char)letraButton.Content;
            letraButton.IsEnabled = false;
            ComprobarLetra(letra.ToString());

        }
        private void IniciarJuego()
        {
            fallos = 0;
            aciertos = 0;
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
        private void NuevaPartidaButton_Click(object sender, RoutedEventArgs e)
        {
            huecoStackpanel.Children.Clear();
            ahorcadoImagen.Source = new BitmapImage(new Uri(@".\assets\0.jpg", UriKind.Relative));
            IniciarJuego();
            for (int i = 0; i < letrasGrid.Children.Count; i++)
            {
                Button boton = (Button)letrasGrid.Children[i];
                boton.IsEnabled = true;
            }
            MessageBox.Show("Has iniciado una nueva partida", "RESULTADO");
        }
        private void AcabarJuego()
        {
            for (int i = 0; i < letrasGrid.Children.Count; i++)
            {
                Button boton = (Button)letrasGrid.Children[i];
                boton.IsEnabled = false;
                ahorcadoImagen.Source = new BitmapImage(new Uri(@".\assets\10.jpg", UriKind.Relative));
            }

            for (int i = 0; i < huecoStackpanel.Children.Count; i++)
            {
                Border b = (Border)huecoStackpanel.Children[i];
                Viewbox vb = b.Child as Viewbox;
                TextBlock tb = vb.Child as TextBlock;

                tb.Visibility = Visibility.Visible;

            }
        }
        private void RendirseButton_Click(object sender, RoutedEventArgs e)
        {
            AcabarJuego();
            MessageBox.Show("Te has rendido", "RESULTADO");
        }
    }
}
