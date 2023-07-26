using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Of_Life.Class
{
	public class NeumannCell : Cell
	{
		public override void CalculateNextStatus(List<Cell> influencingCells)
        {
            throw new NotImplementedException();
        }

		public override int CountAliveNeighbors(List<Cell> neighbors)
		{
			throw new NotImplementedException();
		}
	}
}
