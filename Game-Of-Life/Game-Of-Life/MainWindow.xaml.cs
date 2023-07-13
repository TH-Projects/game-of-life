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

namespace Game_Of_Life
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Game gameInstance;
        public MainWindow()
        {
            InitializeComponent();
            RenderField(40);
            InitCells();
            gameInstance = new Game(this);
        }

        public void RenderField(int fieldSize)
        {
            for (int i = 0; i < fieldSize; i++)
            {
                ColumnDefinition col = new ColumnDefinition();
                RowDefinition row = new RowDefinition();

                cells_grid.ColumnDefinitions.Add(col);
                cells_grid.RowDefinitions.Add(row);
            }
        }

        public void InitCells()
        {
            for (int i = 0; i < 40; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                    Button l = new Button();
                    l.Background = new SolidColorBrush(Colors.White);
                    l.Click += new RoutedEventHandler(onCellClick);
                    Grid.SetColumn(l, i);
                    Grid.SetRow(l, j);
                    cells_grid.Children.Add(l);
                }
            }
        }

        private void onCellClick(object sender, RoutedEventArgs e)
        {
            Button clickedCell = (Button)sender;

            Brush cellColor = clickedCell.Background;
            SolidColorBrush solidCellColorBrush = (SolidColorBrush)cellColor;
           
            if(solidCellColorBrush.Color == Colors.White)
            {
                clickedCell.Background = new SolidColorBrush(Colors.Blue);
            }
            else
            {
                clickedCell.Background = new SolidColorBrush(Colors.White);
            }
        }

		private void Start_Click(object sender, RoutedEventArgs e)
		{

        }

		private void Stop_Reset_Click(object sender, RoutedEventArgs e)
		{

        }
    }
}
