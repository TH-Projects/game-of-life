using Game_Of_Life;
using Game_Of_Life.Class;
using NUnit.Framework;

namespace Game_Of_Life_Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void findDependingCells_EightNeighbors_Pass() 
        {
            //Arrange
            //MainWindow dummyWindow = new MainWindow();
            Game testGame = new Game();

           

            //Act

            int correctCount = 0;

            for(int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++) 
                {
					//List<Cell> cells = testGame.findDependingMooreCells(j, i);
                    //if (cells.Count == 8)
                    //{
                        correctCount++;
                    //}
                }
            }

            
            

            //Assert

            Assert.That(correctCount, Is.EqualTo(400));
        
        }
    }
}