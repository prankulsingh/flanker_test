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
    public partial class Red_Arrow_Fragment : UserControl
    {
        public Red_Arrow_Fragment()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            red_arrow_form form = new red_arrow_form();
            form.Show();
        }
    }
}
