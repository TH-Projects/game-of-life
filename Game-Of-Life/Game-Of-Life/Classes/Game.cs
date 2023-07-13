using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Of_Life.Classes
{
    class Game
    {

        private int fieldLength = 20;
        private bool isEnd = false;
        private CCell[,] cells;

        private MainWindow guiInstance; 

        public Game()
        {
            //guiInstance = new MainWindow();
            cells = new CCell[fieldLength,fieldLength];

            //guiInstance.renderField(fieldLength);
            RunGame();
        }

        private void RunGame()
        {
            while (!isEnd) { 
            

            }
        }
    }
}
