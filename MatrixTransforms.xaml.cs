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
    /// Interaction logic for MatrixTransforms.xaml
    /// </summary>
    public partial class MatrixTransforms : Window
    {
        public MatrixTransforms()
        {
            InitializeComponent();

            // Original matrix:
            Matrix m = new Matrix(1, 2, 3, 4, 0, 1);
            fillMatrix(m, OriginalMatrix);

            //Scale:
            m.Scale(1, 0.5);
            fillMatrix(m, Scale);

            // Scale - Prepend:
            m = new Matrix(1, 2, 3, 4, 0, 1);
            m.ScalePrepend(1, 0.5);
            fillMatrix(m, ScalePrepend);

            //Translation:
            m = new Matrix(1, 2, 3, 4, 0, 1);
            m.Translate(1, 0.5);
            fillMatrix(m,Translation);

            // Translation - Prepend:
            m = new Matrix(1, 2, 3, 4, 0, 1);
            m.TranslatePrepend(1, 0.5);
            fillMatrix(m,TranslationPrepend);

            //Rotation:
            m = new Matrix(1, 2, 3, 4, 0, 1);
            m.Rotate(45);
            fillMatrix(MatrixRound(m), Rotation);

            // Rotation - Prepend:
            m = new Matrix(1, 2, 3, 4, 0, 1);
            m.RotatePrepend(45);
            fillMatrix(MatrixRound(m), RotationPrepend);

            //Rotation at (x = 1, y = 2):
            m = new Matrix(1, 2, 3, 4, 0, 1);
            m.RotateAt(45, 1, 2);
            fillMatrix(MatrixRound(m), RotationAt);

            // Rotation at (x = 1, y = 2) - Prepend:
            m = new Matrix(1, 2, 3, 4, 0, 1);
            m.RotateAtPrepend(45, 1, 2);
            fillMatrix(MatrixRound(m), RotationAtPrepend);

            // Skew:
            m = new Matrix(1, 2, 3, 4, 0, 1);
            m.Skew(45, 30);
            fillMatrix(MatrixRound(m), Skew);

            // Skew - Prepend:
            m = new Matrix(1, 2, 3, 4, 0, 1);
            m.SkewPrepend(45, 30);
            fillMatrix(MatrixRound(m), SkewPrepend);
        }
        private Matrix MatrixRound(Matrix m)
        {
            m.M11 = Math.Round(m.M11, 3);
            m.M12 = Math.Round(m.M12, 3);
            m.M21 = Math.Round(m.M21, 3);
            m.M22 = Math.Round(m.M22, 3);
            m.OffsetX = Math.Round(m.OffsetX, 3);
            m.OffsetY = Math.Round(m.OffsetY, 3);
            return m;
        }

        public void fillMatrix(Matrix mm, Panel p)
        {
            int i = 0;
            string elements = mm.ToString();
            string[] s = elements.Split(',');

            foreach (var tb in p.Children.OfType<TextBlock>())
            {
                tb.Text = s[i];
                i++;
            }
        }
    }
}
