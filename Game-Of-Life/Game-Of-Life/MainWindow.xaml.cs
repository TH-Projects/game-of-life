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
        public MainWindow()
        {
            InitializeComponent();
            renderField(20);
        }

        public void renderField(int fieldSize)
        {
            cells_grid.ShowGridLines = true;
            for (int i = 0; i < fieldSize; i++)
            {
                ColumnDefinition col = new ColumnDefinition();
                RowDefinition row = new RowDefinition();

                cells_grid.ColumnDefinitions.Add(col);
                cells_grid.RowDefinitions.Add(row);
            }
        }
    }
}
