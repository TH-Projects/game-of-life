using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Navigation;

namespace Game_Of_Life.Class
{
	public abstract class Cell
	{
		protected bool _isAlive = false;
		protected bool _nextStatus = true;
		protected SolidColorBrush _color = new SolidColorBrush(Colors.White);

		public bool IsAlive { get => _isAlive; 
			set
			{
				if (value)
				{
					_isAlive = true;
					_color = new SolidColorBrush(Colors.Blue);
				}
				else
				{
					_isAlive = false;
					_color = new SolidColorBrush(Colors.White);
				}
			} 
		}

		public bool NextStatus { get; set; }

		public SolidColorBrush Color { get => _color; set => _color = value; }

		public abstract void CalculateNextStatus(List<Cell> influencingCells); //calculates if the status of the cell for the next round

		public abstract int CountAliveNeighbors(List<Cell> neighbors); //counts how many cells of parameter list are alive

		public void ApplyNextGeneration() //applies the calculated next status on the current one
		{
			IsAlive = _nextStatus;
		}
		
	}
}
