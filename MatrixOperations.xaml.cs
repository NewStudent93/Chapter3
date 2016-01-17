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

namespace Chapter3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Invert matrix:
            Matrix m = new Matrix(1, 2, 3, 4, 0, 0);
            fillMatrix(m, OriginalMatrix);
            m.Invert();
            fillMatrix(m, InvertedMarix);

            // Matrix multiplication:
            Matrix m1 = new Matrix(1, 2, 3, 4, 0, 1);
            Matrix m2 = new Matrix(0, 1, 2, 1, 0, 1);
            fillMatrix(m1, OriginalMatrix1);
            fillMatrix(m2, OriginalMatrix2);

            Matrix m12 = Matrix.Multiply(m1, m2);
            Matrix m21 = Matrix.Multiply(m2, m1);
            fillMatrix(m12, m1xm2);
            fillMatrix(m21, m2xm1);

           
        }
        public void fillMatrix(Matrix mm,Panel p)
        {
            int i = 0;
            string elements = mm.ToString();
            string[] s = elements.Split(',');

             foreach(var tb in p.Children.OfType<TextBlock>())
            {
                tb.Text = s[i];
                i++;
            }
        }
    }
}
