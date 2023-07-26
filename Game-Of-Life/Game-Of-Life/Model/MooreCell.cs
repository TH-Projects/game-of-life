using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Of_Life.Class
{
	public class MooreCell : Cell
	{
		public override void CalculateNextStatus(List<Cell> influencingCells)
		{ 
			int aliveNeighbors = CountAliveNeighbors(influencingCells);
			if (_isAlive) 
				_nextStatus = (aliveNeighbors == 2 || aliveNeighbors == 3); 
			else 
				_nextStatus = (aliveNeighbors == 3);
		}

		public override int CountAliveNeighbors(List<Cell> neighbors)
		{
			int aliveCount = 0;
			foreach (Cell cell in neighbors)
				if (cell.IsAlive) aliveCount++;
			return aliveCount;
		}
	}
}
