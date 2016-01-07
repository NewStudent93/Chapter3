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
using System.Windows.Shapes;

namespace Chapter3
{
    /// <summary>
    /// Interaction logic for Default.xaml
    /// </summary>
    public partial class Default : Window
    {
        public Default()
        {
            InitializeComponent();
        }

        public void btnArrowLine_Click(object sender, RoutedEventArgs e)
        {
            LineArrow la = new LineArrow();
            la.Show();
    //        this.Close();            
        }

        public void btnMatrixOperations_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MO = new MainWindow();
            MO.Show();
    //        this.Close();
        }

        public void btnPerpendicularLine_Click(object sender, RoutedEventArgs e)
        {
            PerpendicularLine PL = new PerpendicularLine();
            PL.Show();
    //        this.Close();
        }

        public void btnMatrixTransforms_Click(object sender, RoutedEventArgs e)
        {
            MatrixTransforms MT = new MatrixTransforms();
            MT.Show();
    //        this.Close();
        }

        public void btnObjectMatrixTransforms_Click(object sender, RoutedEventArgs e)
        {
            ObjectMatrixTransform OMT = new ObjectMatrixTransform();
            OMT.Show();
   //         this.Close();
        }

        public void btnScaleTransforms_Click(object sender, RoutedEventArgs e)
        {
            ScaleTransforms ST = new ScaleTransforms();
            ST.Show();
    //        this.Close();
        }

        public void btnTranslateTransforms_Click(object sender, RoutedEventArgs e)
        {
            TranslateTransforms TT = new TranslateTransforms();
            TT.Show();
   //         this.Close();
        }

        public void btnRotateTransfors_Click(object sender, RoutedEventArgs e)
        {
            RotateTransforms RT = new RotateTransforms();
            RT.Show();
    //        this.Close();
        }
    }
}
