using Game_Of_Life.Class;
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
			gameInstance = new Game(this);
		}

		public void InitGrid(int fieldSize, Cell[,] cells) //initializes a grid for the cells in the requested size
		{
			//cells_grid.ShowGridLines = true;
			for (int i = 0; i < fieldSize; i++)
			{
				ColumnDefinition col = new ColumnDefinition();
				RowDefinition row = new RowDefinition();

				cells_grid.ColumnDefinitions.Add(col);
				cells_grid.RowDefinitions.Add(row);
			}
			AddButtons(fieldSize);
			RefreshColors(fieldSize,cells);
		}

		private void AddButtons(int fieldSize) //Puts a button in each grid field for representing the cell
		{
			for (int i = 0; i < fieldSize; i++)
			{
				for (int j = 0; j < fieldSize; j++)
				{
					Button l = new Button();
					l.Background = new SolidColorBrush(Colors.Blue);
					l.Click += new RoutedEventHandler(onCellClick);
					Grid.SetColumn(l, i);
					Grid.SetRow(l, j);
					cells_grid.Children.Add(l);

				}
			}
		}

		public void RefreshColors(int fieldSize, Cell[,] cells)
		{
			for (int i = 0; i < fieldSize; i++)
			{
				for (int j = 0; j < fieldSize; j++)
				{
					Button targetButton = (Button)cells_grid.Children
														 .Cast<Button>()
														 .First(e => Grid.GetRow(e) == i && Grid.GetColumn(e) == j);
					targetButton.Background = cells[j,i].Color;
				}
			}
		}


		private void onCellClick(object sender, RoutedEventArgs e)
		{
			gameInstance.cellClicked(sender);
		}

		private void onClickStart(object sender, RoutedEventArgs e)
		{
			gameInstance.StartGame();
		}

		private void onStopClick(object sender, RoutedEventArgs e)
		{
			gameInstance.IsRunning = false;
		}

		public void RefreshCounter(int roundCounter)
		{
			lbl_RoundCounter.Text = $"Runde: {roundCounter}";
		}
	}
}
