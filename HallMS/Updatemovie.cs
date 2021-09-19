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
    public partial class Updatemovie : Form
    {
        public Updatemovie()
        {
            InitializeComponent();
        }
        movie s = new movie();
        DataAccess da = new DataAccess();
        DataTable dt = new DataTable();

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Updatemovie_Load(object sender, EventArgs e)
        {
            dt = da.allmovie(s);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;

            textBoxUname.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            comboBoxBlock.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();//showname
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();//type
            dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();//price
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();//date
            comboBox2.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();//start
            label9.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//start

            numericUpDown1.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();//status
            comboBox3.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();//slot
            //position
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBoxUname.Text == "" || dateTimePicker1.Text == "" || textBox1.Text == "" || comboBoxBlock.Text == "" || comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || numericUpDown1.Text == "" || textBoxUname.Text == "")
            {
                MessageBox.Show("Please fill all the information");
            }
            else
            {
                if (label9.Text == "----")
                {
                    MessageBox.Show("Please Select a MovieList");
                }
                else
                {
                    s.sl = Int32.Parse(label9.Text);
                    s.showname = textBoxUname.Text;
                    s.type = comboBoxBlock.Text;
                    s.date = dateTimePicker1.Text;
                    s.start = comboBox1.Text;
                    s.end = comboBox2.Text;
                    s.slot = numericUpDown1.Text;
                    s.position = comboBox3.Text;
                    s.price = textBox1.Text;

                    int w = da.updatemovie(s);
                    if (w > 0)
                    {
                        MessageBox.Show("Show updated");
                        dt = da.allmovie(s);
                        dataGridView1.DataSource = dt;
                    }

                    else { MessageBox.Show("Server busy try again"); }
                }
            }
        }
    }
}
