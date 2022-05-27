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

namespace Tolvaj_Bence_Sakk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Button[,] babuk;
        List<char> letters = new List<char>() { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
        List<string> options = new List<string> { "Király", "Fehér paraszt", "Fekete paraszt", "Bástya", "Királynő", "Futó", "Huszár" };
        List<string> legalmoves = new List<string>();
        static int x;
        static int y;
        public MainWindow()
        {
            InitializeComponent();
            opciok.ItemsSource = options;
            opciok.SelectedIndex = 0;
        }
        public void KingMove()
        {

            if (y - 1 > 0)
            {
                babuk[x, y - 1].Background = Brushes.Red;
                legalmoves.Add(letters[y - 1] + Convert.ToString(x + 1));
            }
            if (x + 1 < 8)
            {
                babuk[x + 1, y].Background = Brushes.Red;
                legalmoves.Add(letters[y] + Convert.ToString(x + 2));
                if (y - 1 >= 0)
                {
                    babuk[x + 1, y - 1].Background = Brushes.Red;
                    legalmoves.Add(letters[y - 1] + Convert.ToString(x + 2));
                }
                if (y + 1 < 8)
                {
                    babuk[x + 1, y + 1].Background = Brushes.Red;
                    legalmoves.Add(letters[y + 1] + Convert.ToString(x + 2));
                }
            }
            if (y + 1 < 8)
            {
                babuk[x, y + 1].Background = Brushes.Red;
                legalmoves.Add(letters[y + 1] + Convert.ToString(x + 1));
                if (x + 1 < 8)
                {
                    babuk[x + 1, y].Background = Brushes.Red;
                    legalmoves.Add(letters[y] + Convert.ToString(x + 2));
                }
            }
            if (x - 1 >= 0)
            {
                babuk[x - 1, y].Background = Brushes.Red;
                legalmoves.Add(letters[y] + Convert.ToString(x));
                if (y - 1 >= 0)
                {
                    babuk[x - 1, y - 1].Background = Brushes.Red;
                    legalmoves.Add(letters[y - 1] + Convert.ToString(x));
                }
                if (y + 1 < 8)
                {
                    babuk[x - 1, y + 1].Background = Brushes.Red;
                    legalmoves.Add(letters[y + 1] + Convert.ToString(x));
                }
            }
        }
        public void FeherParaszt()
        {
            if (x - 1 >= 0)
            {
                babuk[x - 1, y].Background = Brushes.Red;
                legalmoves.Add(letters[y] + Convert.ToString(x));
            }
            if (x == 6)
            {
                babuk[x - 2, y].Background = Brushes.Red;
                legalmoves.Add(letters[y] + Convert.ToString(x - 1));
            }
        }
        public void FeketeParaszt()
        {
            if (x + 1 < 8)
            {
                babuk[x + 1, y].Background = Brushes.Red;
                legalmoves.Add(letters[y] + Convert.ToString(x + 2));
            }
            if (x == 1)
            {
                babuk[x + 2, y].Background = Brushes.Red;
                legalmoves.Add(letters[y] + Convert.ToString(x + 3));
            }
        }
        public void FutoMove()
        {
            int xcopy = x;
            int ycopy = y;
            while (xcopy + 1 < 8 && ycopy + 1 < 8)
            {
                xcopy++;
                ycopy++;
                babuk[xcopy, ycopy].Background = Brushes.Red;
                string move = letters[ycopy] + Convert.ToString(xcopy + 1);
                legalmoves.Add(move);
            }
            xcopy = x;
            ycopy = y;
            while (xcopy - 1 >= 0 && ycopy + 1 < 8)
            {
                xcopy--;
                ycopy++;
                babuk[xcopy, ycopy].Background = Brushes.Red;
                string move = letters[ycopy] + Convert.ToString(xcopy + 1);
                legalmoves.Add(move);
            }
            xcopy = x;
            ycopy = y;
            while (xcopy - 1 >= 0 && ycopy - 1 >= 0)
            {
                xcopy--;
                ycopy--;
                babuk[xcopy, ycopy].Background = Brushes.Red;
                string move = letters[ycopy] + Convert.ToString(xcopy + 1);
                legalmoves.Add(move);
            }
            xcopy = x;
            ycopy = y;
            while (xcopy + 1 < 8 && ycopy - 1 >= 0)
            {
                xcopy++;
                ycopy--;
                babuk[xcopy, ycopy].Background = Brushes.Red;
                string move = letters[ycopy] + Convert.ToString(xcopy + 1);
                legalmoves.Add(move);
            }
            xcopy = x;
            ycopy = y;
        }
        public void RookMove()
        {
            for (int i = x; i < 8; i++)
            {
                babuk[i, y].Background = Brushes.Red;
                legalmoves.Add(letters[y] + Convert.ToString(i + 1));
            }
            for (int i = x; i >= 0; i--)
            {
                babuk[i, y].Background = Brushes.Red;
                legalmoves.Add(letters[y] + Convert.ToString(i + 1));
            }
            for (int i = y; i < 8; i++)
            {
                babuk[x, i].Background = Brushes.Red;
                legalmoves.Add(letters[i] + Convert.ToString(x + 1));
            }
            for (int i = y; i >= 0; i--)
            {

                babuk[x, i].Background = Brushes.Red;
                legalmoves.Add(letters[i] + Convert.ToString(x + 1));

            }
            babuk[x, y].Background = Brushes.Yellow;

        }
        public void HuszarMove()
        {
            if (x - 2 >= 0)
            {
                if (y + 1 < 8)
                {
                    babuk[x - 2, y + 1].Background = Brushes.Red;
                    legalmoves.Add(letters[y + 1] + Convert.ToString(x - 1));
                }
                if (y - 1 >= 0)
                {
                    babuk[x - 2, y - 1].Background = Brushes.Red;
                    legalmoves.Add(letters[y - 1] + Convert.ToString(x - 1));
                }
            }
            if (x + 2 < 8)
            {
                if (y + 1 < 8)
                {
                    babuk[x + 2, y + 1].Background = Brushes.Red;
                    legalmoves.Add(letters[y + 1] + Convert.ToString(x + 3));
                }
                if (y - 1 >= 0)
                {
                    babuk[x + 2, y - 1].Background = Brushes.Red;
                    legalmoves.Add(letters[y - 1] + Convert.ToString(x + 3));
                }
            }
            if (y + 2 < 8)
            {
                if (x + 1 < 8)
                {
                    babuk[x + 1, y + 2].Background = Brushes.Red;
                    legalmoves.Add(letters[y + 2] + Convert.ToString(x + 2));
                }
                if (x - 1 >= 0)
                {
                    babuk[x - 1, y + 2].Background = Brushes.Red;
                    legalmoves.Add(letters[y + 2] + Convert.ToString(x));
                }
            }
            if (y - 2 >= 0)
            {
                if (x + 1 < 8)
                {
                    babuk[x + 1, y - 2].Background = Brushes.Red;
                    legalmoves.Add(letters[y - 2] + Convert.ToString(x + 2));
                }
                if (x - 1 >= 0)
                {
                    babuk[x - 1, y - 2].Background = Brushes.Red;
                    legalmoves.Add(letters[y - 2] + Convert.ToString(x));
                }
            }

        }

        public void General()
        {
            babuk = new Button[8, 8];
            for (int i = 0; i < 10; i++)
            {
                tabla.ColumnDefinitions.Add(new ColumnDefinition());
                tabla.RowDefinitions.Add(new RowDefinition());
            }
            for (int i = 0; i < 8; i++)
            {
                Label temp = new Label();
                temp.Foreground = Brushes.Black;
                temp.Content = letters[i];
                tabla.Children.Add(temp);
                Grid.SetRow(temp, 0);
                Grid.SetColumn(temp, i + 1);
            }
            for (int i = 1; i < 9; i++)
            {
                Label temp = new Label();
                temp.Foreground = Brushes.Black;
                temp.Content = i;
                tabla.Children.Add(temp);
                Grid.SetRow(temp, i);
                Grid.SetColumn(temp, 0);
            }
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    Button temp = new Button();
                    if (i % 2 != 0 && j % 2 == 0 || i % 2 == 0 && j % 2 != 0)
                    {
                        temp.Background = Brushes.Green;
                    }
                    else
                    {
                        temp.Background = Brushes.Beige;
                    }
                    temp.Click += Temp_Click;
                    babuk[i - 1, j - 1] = temp;
                    tabla.Children.Add(babuk[i - 1, j - 1]);
                    Grid.SetRow(temp, i);
                    Grid.SetColumn(temp, j);
                }
            }
        }
        private void Temp_Click(object sender, RoutedEventArgs e)
        {
            legalmoves.Clear();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i % 2 != 0 && j % 2 == 0 || i % 2 == 0 && j % 2 != 0)
                    {
                        babuk[i, j].Background = Brushes.Green;
                    }
                    else
                    {
                        babuk[i, j].Background = Brushes.Beige;
                    }
                    babuk[i, j].FontSize = 30;
                    babuk[i, j].Content = "";

                }
            }
            legalislepesek.Text = "";
            pozicio.Content = " ";
            Button temp = (Button)sender;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (babuk[i, j] == temp)
                    {
                        x = i;
                        y = j;
                    }
                }
            }
            babuk[x, y].Background = Brushes.Yellow;
            switch (opciok.SelectedItem)
            {
                case ("Király"):
                    babuk[x, y].Content = "♔";

                    KingMove();
                    break;
                case ("Fehér paraszt"):
                    babuk[x, y].Content = "♙";
                    FeherParaszt();
                    break;
                case ("Fekete paraszt"):
                    babuk[x, y].Content = "♟";
                    FeketeParaszt();
                    break;
                case ("Királynő"):
                    babuk[x, y].Content = "♕";
                    FutoMove();
                    RookMove();
                    break;
                case ("Futó"):
                    babuk[x, y].Content = "♗";
                    FutoMove();
                    break;
                case ("Bástya"):
                    babuk[x, y].Content = "♖";
                    RookMove();
                    break;
                case ("Huszár"):
                    babuk[x, y].Content = "♘";
                    HuszarMove();
                    break;

            }
            pozicio.Content = letters[y] + Convert.ToString(y);
            foreach (var lepes in legalmoves)
            {
                legalislepesek.Text += lepes + ",";
            }

        }



    }
}
