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

    }
}
