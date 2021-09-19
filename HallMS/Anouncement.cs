using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HallMS
{
    public partial class Anouncement : Form
    {
        public Anouncement()
        {
            InitializeComponent();
        }
        DataAccess da = new DataAccess();
        movie a = new movie();
        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                MessageBox.Show("Please Write something");
            }
            else
            {
                a.text = richTextBox1.Text;
                int w = da.UpdateAnouncement(a);
                if (w > 0)
                {
                    MessageBox.Show("Published");




                }
            }
        }
    }
}
