using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Arrow_Fragement : UserControl
    {
        public Arrow_Fragement()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            arrow form = new arrow();
            form.Show();
        }
    }
}
