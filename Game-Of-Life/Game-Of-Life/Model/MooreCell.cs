using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Of_Life.Class
{
	public class MooreCell : Cell
	{

		public override void CalcNextStatus(List<Cell> influencingCells)
		{ 
			int aliveNeighbors = CountAliveNeighbors(influencingCells);
			if (isAlive) 
				nextStatus = (aliveNeighbors == 2 || aliveNeighbors == 3); 
			else 
				nextStatus = (aliveNeighbors == 3);
		}

		public int CountAliveNeighbors(List<Cell> neighbors)
		{
			int aliveCount = 0;
			foreach (Cell cell in neighbors)
				if (cell.IsAlive) aliveCount++;
			return aliveCount;
		}
		public override void ApplyNextGeneration()
		{
			IsAlive = nextStatus;
		}	
	}
}
