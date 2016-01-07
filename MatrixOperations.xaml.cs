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
            tbOriginal.Text = "(" + m.ToString() + ")";
            m.Invert();
            tbInvert.Text = "(" + m.ToString() + ")";
            // Matrix multiplication:
            Matrix m1 = new Matrix(1, 2, 3, 4, 0, 1);
            Matrix m2 = new Matrix(0, 1, 2, 1, 0, 1);
            Matrix m12 = Matrix.Multiply(m1, m2);
            Matrix m21 = Matrix.Multiply(m2, m1);
            tbM1M2.Text = "M1 = (" + m1.ToString() + "), " + " M2 = (" + m2.ToString() + ")";
            tbM12.Text = "(" + m12.ToString() + ")";
            tbM21.Text = "(" + m21.ToString() + ")";
        }
    }
}
