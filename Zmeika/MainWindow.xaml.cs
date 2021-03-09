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
using System.Threading;
using System.Windows.Threading;

namespace Zmeika
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int currentRow = 1;
        int currentCol = 1;
        int ran = 0;
        int ran2 = 0;
        int index = 1;      
        int tekusheeCol = 0;
        int tekusheeRow = 0;                       
        Random random = new Random();
        List<Rectangle> rectangles = new List<Rectangle>();
        List<int> colum = new List<int>();
        List<int> row = new List<int>();
        Key key = Key.D;
        
        public MainWindow()
        {
            InitializeComponent();
            Random();
            rectangles.Add(isi);
            Move_First();
            
            this.KeyDown += Right_Click;                
          
        }
               

        private void Right_Click(object sender, KeyEventArgs e)
        {
            key = e.Key;
                       
        }
        private async void Move_First()
        {
            
            do
            {
                tekusheeCol = Grid.GetColumn(isi);
                tekusheeRow = Grid.GetRow(isi);

                switch (key)
                {
                    case Key.W:

                        currentRow = tekusheeRow - 1;
                        
                        Move_Objects();
                        await Task.Delay(500);
                        break;
                    case Key.S:

                        currentRow = tekusheeRow + 1;
                        
                        Move_Objects();
                        await Task.Delay(500);
                        break;
                    case Key.A:

                        currentCol = tekusheeCol - 1;
                        
                        Move_Objects();
                        await Task.Delay(500);
                        break;
                    case Key.D:

                        currentCol = tekusheeCol + 1;
                        
                        Move_Objects();
                        await Task.Delay(500);
                        break;
                }
                
                if (currentCol == ran && currentRow == ran2)
                {
                    Random();
                    AddObject();
                }
                
            } while (true);
        }
        
        private void Random()
        {
           ran = random.Next(0, 24);
           ran2 = random.Next(0, 24);
            Grid.SetColumn(Eat, ran);
            Grid.SetRow(Eat, ran2);
        }
        
        private void AddObject()
        {

            rectangles.Add(new Rectangle { Width =38, Height =18, Fill = Brushes.Black, Stroke = Brushes.Black});
            
            MaainMoot.Children.Add(rectangles[index]);
           
            Grid.SetColumn(rectangles[index], colum[0]);
            Grid.SetRow(rectangles[index], row[0]);
            
            index++;
            
        }
        private void Move_Objects() 
        {

            if (rectangles.Count != 0)
            {

                if (colum.Count > 0 && row.Count > 0)
                {
                    colum.RemoveAt(0);
                    row.RemoveAt(0);
                }
                colum.Add(tekusheeCol);
                row.Add(tekusheeRow);
                Grid.SetColumn(rectangles[0], currentCol);
                Grid.SetRow(rectangles[0], currentRow);


                for (int i = 1; i < rectangles.Count; i++)
                {
                    colum.Add(Grid.GetColumn(rectangles[i]));
                    row.Add(Grid.GetRow(rectangles[i]));
                    Grid.SetColumn(rectangles[i], colum[0]);
                    Grid.SetRow(rectangles[i], row[0]);
                    colum.RemoveAt(0);
                    row.RemoveAt(0);




                }
            } 
            
        }


        
    }
}