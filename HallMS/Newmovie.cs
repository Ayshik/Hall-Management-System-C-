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
    public partial class Newmovie : Form
    {
        public Newmovie()
        {
            InitializeComponent();
        }
        movie s = new movie();
        DataAccess da = new DataAccess();
        DataTable dt = new DataTable();
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Newmovie_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxUname.Text == "" ||  dateTimePicker1.Text == "" || textBox1.Text == "" || comboBoxBlock.Text == "" || comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == ""|| numericUpDown1.Text == "" || textBoxUname.Text == "")
            {
                MessageBox.Show("Please fill all the information");
            }
            else
            {
                s.showname= textBoxUname.Text;
                s.type = comboBoxBlock.Text;
                s.date = dateTimePicker1.Text;
                s.start = comboBox1.Text;
                s.end = comboBox2.Text;
                s.slot = numericUpDown1.Text;
                s.position = comboBox3.Text;
                s.price = textBox1.Text;



                int i = da.Addmovie(s);
                if (i > 0)
                {
                    MessageBox.Show("Show Added");
                }
                else
                {
                    MessageBox.Show("opss server is Busy");
                }
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
