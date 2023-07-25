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
		protected bool isAlive = false;
		protected bool nextStatus = true;
		protected SolidColorBrush color = new SolidColorBrush(Colors.White);

		

		public bool IsAlive { get => isAlive; 
			set
			{
				if (value)
				{
					isAlive = true;
					color = new SolidColorBrush(Colors.Blue);
				}
				else
				{
					isAlive = false;
					color = new SolidColorBrush(Colors.White);
				}
			} 
		}

		public bool NextStatus { get; set; }

		public SolidColorBrush Color { get => color; set => color = value; }

		public abstract void CalcNextStatus(List<Cell> influencingCells);
		public abstract void ApplyNextGeneration();
		
	}
}
