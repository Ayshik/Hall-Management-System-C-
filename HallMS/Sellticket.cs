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
    public partial class Sellticket : Form
    {
        public Sellticket()
        {
            InitializeComponent();
        }
        movie s = new movie();
        Ticket t= new Ticket();
        DataAccess da = new DataAccess();
        DataTable dt = new DataTable();
        private void textBoxUname_TextChanged(object sender, EventArgs e)
        {
            s.showname = textBoxUname.Text;

            dt = da.moviesearch(s);
            dataGridView1.DataSource = dt;

        }

        private void Sellticket_Load(object sender, EventArgs e)
        {
            dt = da.movielist(s);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;

            label3.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            label4.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();//showname
            label5.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();//type
            label6.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();//price
            label7.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();//date
            label9.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();//start
            label11.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//end
            label13.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();//status
            label12.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();//slot
            //position

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter Buyer Name");
            }
            else
            {
                if (label4.Text == "----" || label5.Text == "----")

                {
                    MessageBox.Show("Please select a Show");
                }
                else
                {

                    int input = Convert.ToInt16(numericUpDown1.Text);
                    int newno = Convert.ToInt16(label13.Text) - input;
                    if (newno <= 0)

                    {

                        t.sl = Int32.Parse(label11.Text);
                        t.updateslot = newno.ToString();
                        t.ticket = numericUpDown1.Text;
                        t.showname = label3.Text;
                        t.type = label4.Text;
                        t.price = label5.Text;
                        t.date = label6.Text;
                        t.start = label7.Text;
                        t.end = label9.Text;
                        t.bname = textBox1.Text;
                        t.bphone = textBox2.Text;

                        t.slot = label11.Text;
                        t.position = label12.Text;

                        da.sellticket(t);
                        MessageBox.Show("There Are no seat In this Area");

                       


                        int w = da.updateslot(t);
                    }
                    else
                    {
                        t.sl = Int32.Parse(label11.Text);
                        t.updateslot = newno.ToString();
                        t.ticket = numericUpDown1.Text;
                        t.showname = label3.Text;
                        t.type = label4.Text;
                        t.price = label5.Text;
                        t.date = label6.Text;
                        t.start = label7.Text;
                        t.end = label9.Text;
                        t.bname = textBox1.Text;
                        t.bphone = textBox2.Text;

                        t.slot = label11.Text;
                        t.position = label12.Text;

                        da.sellticket(t);
                        {

                            MessageBox.Show("Ticket Sold");

                        }
                    }
                }
            }
        }
    }
}
