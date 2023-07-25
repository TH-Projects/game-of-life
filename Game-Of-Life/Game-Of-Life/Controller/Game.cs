using Game_Of_Life.Class;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Game_Of_Life
{
	public class Game
	{
		private MainWindow guiInstance;

		private Cell[,] cells;

		private int fieldLength = 20;
		private bool isRunning = true;
		private int roundCounter = 0;


		public Cell[,] Cells { get { return cells; } }
		public int FieldLength { get { return fieldLength; } }
		public bool IsRunning { get { return isRunning; } set { isRunning = value; } }


		public Game(MainWindow guiInstance)
		{
			this.guiInstance = guiInstance;

			cells = new MooreCell[fieldLength, fieldLength];
			InitCells();
			guiInstance.InitGrid(fieldLength, cells);
			
		}

        public Game()
        {
			cells = new MooreCell[fieldLength, fieldLength];
			InitCells();
		}

        public async void StartGame()
		{
			while (isRunning) 
			{
				PlayRound();
				await Task.Delay(500);
			}

		}

		public void PlayRound() {
			
			for (int i = 0; i < cells.GetLength(0); i++)
			{
				for (int j = 0; j < cells.GetLength(1); j++)
				{
					List<Cell> neighborCells = findDependingMooreCells(j,i);
					cells[j, i].CalcNextStatus(neighborCells);
				}
			}

			for (int i = 0;i < cells.GetLength(0); i++)
			{
				for (int j = 0;j < cells.GetLength(1); j++)
				{
					cells[j, i].ApplyNextGeneration();
				}
			}

			roundCounter++;
			guiInstance.RefreshCounter(roundCounter);
			guiInstance.RefreshColors(fieldLength, cells);

		}

		private void InitCells() //creates a Cell instance in every field of the array
		{
			for (int i = 0; i < cells.GetLength(0); i++)
			{
				for (int j = 0; j < cells.GetLength(1); j++)
				{
					cells[j, i] = new MooreCell();
				}
			}
		} 

		private (int, int) getCellCordsInGrid(Button eventSender) //returns the x and y coordinate of a button in the grid
		{
			int xCord = (int)eventSender.GetValue(Grid.ColumnProperty);
			int yCord = (int)eventSender.GetValue(Grid.RowProperty);

			(int x, int y) coordinates = (xCord, yCord);

			return coordinates;
		}

		private void changeCellStatus(int x, int y) //inverts the status of a cell
		{
			cells[x, y].IsAlive = !cells[x, y].IsAlive;
		}

		public List<Cell> findDependingMooreCells(int cellColumn, int cellRow) //returns all eight neighbors of a cell
		{
			List<Cell> neighbors = new List<Cell>();
			int rows = cells.GetLength(0);
			int cols = cells.GetLength(1);

			for (int i = -1; i <= 1; i++)
			{
				for (int j = -1; j <= 1; j++)
				{
					if (i == 0 && j == 0)
						continue;

					int neighborRow = (cellRow + i + rows) % rows; // Periodische Randbedingung für Zeilen
					int neighborCol = (cellColumn + j + cols) % cols; // Periodische Randbedingung für Spalten

					neighbors.Add(cells[neighborCol, neighborRow]);
				}
			}

			return neighbors;
		}

		public void cellClicked(object sender) //logic for click on a cell
		{
			(int xCord, int yCord) cellCoordinates = getCellCordsInGrid((Button)sender);
			changeCellStatus(cellCoordinates.xCord, cellCoordinates.yCord);
			guiInstance.RefreshColors(fieldLength, cells);
		}
	}
}
