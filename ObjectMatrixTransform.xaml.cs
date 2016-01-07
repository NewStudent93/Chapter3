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
    /// Interaction logic for ObjectMatrixTransform.xaml
    /// </summary>
    public partial class ObjectMatrixTransform : Window
    {
        public ObjectMatrixTransform()
        {
            InitializeComponent();
        }
            public void BtnApply_Click(object sender, EventArgs e)
        {
            Matrix m = new Matrix();
            m.M11 = Double.Parse(tbM11.Text);
            m.M12 = Double.Parse(tbM12.Text);
            m.M21 = Double.Parse(tbM21.Text);
            m.M22 = Double.Parse(tbM22.Text);
            m.OffsetX = Double.Parse(tbOffsetX.Text);
            m.OffsetY = Double.Parse(tbOffsetY.Text);
            matrixTransform.Matrix = m;
        }
        public void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    
    }
}
