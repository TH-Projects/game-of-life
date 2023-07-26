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
		private MainWindow _guiInstance;
		private Cell[,] _cells;

		private int _fieldLength = 30;
		private bool _isRunning = true;
		private int _roundCounter = 0;

		public Cell[,] Cells { get => _cells; }
		public int FieldLength { get => _fieldLength; }
		public bool IsRunning { get => _isRunning; set => _isRunning = value; }

		public Game(MainWindow guiInstance)
		{
			_guiInstance = guiInstance;
			_cells = new MooreCell[_fieldLength, _fieldLength];
			InitCells();
			_guiInstance.InitGrid(_fieldLength, _cells);
		}

        public async void Play() //plays the game until it is finished
		{
			_isRunning = true;
			while (_isRunning) 
			{
				PlayRound();
				await Task.Delay(500);
			}
		}

		public void ResetGame() //resets the game grid and cells array
		{
			for (int i = 0; i < _cells.GetLength(0); i++)
				for (int j = 0; j < _cells.GetLength(1); j++)
					_cells[j,i].IsAlive = false;
			_roundCounter = 0;
			_guiInstance.RefreshCounter(_roundCounter);
			_guiInstance.ClearGrid();
			_guiInstance.InitGrid(_fieldLength, _cells);
		}

		public void PlayRound() //all logic which is proceeds every round
		{
			for (int i = 0; i < _cells.GetLength(0); i++)
			{
				for (int j = 0; j < _cells.GetLength(1); j++)
				{
					List<Cell> neighborCells = FindDependingMooreCells(j,i);
					_cells[j, i].CalculateNextStatus(neighborCells);
				}
			}
			for (int i = 0;i < _cells.GetLength(0); i++)
			{
				for (int j = 0;j < _cells.GetLength(1); j++)
				{
					_cells[j, i].ApplyNextGeneration();
				}
			}
			_roundCounter++;
			_guiInstance.RefreshCounter(_roundCounter);
			_guiInstance.RefreshColors(_fieldLength, _cells);
		}

		private void InitCells() //creates a cell instance in every field of the array
		{
			for (int i = 0; i < _cells.GetLength(0); i++)
			{
				for (int j = 0; j < _cells.GetLength(1); j++)
				{
					_cells[j, i] = new MooreCell();
				}
			}
		} 

		private (int, int) GetCellCordsInGrid(Button eventSender) //returns the x and y coordinate of a button in the grid
		{
			int xCord = (int)eventSender.GetValue(Grid.ColumnProperty);
			int yCord = (int)eventSender.GetValue(Grid.RowProperty);
			(int x, int y) coordinates = (xCord, yCord);
			return coordinates;
		}

		private void ChangeCellStatus(int x, int y) //inverts the status of a cell
		{
			_cells[x, y].IsAlive = !_cells[x, y].IsAlive;
		}

		public List<Cell> FindDependingMooreCells(int cellColumn, int cellRow) //returns all eight neighbors of a cell
		{
			List<Cell> neighbors = new List<Cell>();
			int rows = _cells.GetLength(0);
			int cols = _cells.GetLength(1);
			for (int i = -1; i <= 1; i++)
			{
				for (int j = -1; j <= 1; j++)
				{
					if (i == 0 && j == 0)
						continue;
					int neighborRow = (cellRow + i + rows) % rows; // Periodische Randbedingung für Zeilen
					int neighborCol = (cellColumn + j + cols) % cols; // Periodische Randbedingung für Spalten
					neighbors.Add(_cells[neighborCol, neighborRow]);
				}
			}
			return neighbors;
		}

		public void CellClicked(object sender) //logic for click on a cell
		{
			(int xCord, int yCord) cellCoordinates = GetCellCordsInGrid((Button)sender);
			ChangeCellStatus(cellCoordinates.xCord, cellCoordinates.yCord);
			_guiInstance.RefreshColors(_fieldLength, _cells);
		}
	}
}
