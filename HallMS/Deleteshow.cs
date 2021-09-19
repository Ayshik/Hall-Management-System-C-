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
    public partial class Deleteshow : Form
    {
        public Deleteshow()
        {
            InitializeComponent();
        }
        movie s = new movie();
        DataAccess da = new DataAccess();
        DataTable dt = new DataTable();
        private void Deleteshow_Load(object sender, EventArgs e)
        {
            dt = da.allmovie(s);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (label11.Text == "----")
            {
                MessageBox.Show("please select a Show from Table");

            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("Do You Want Delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    s.sl = Int32.Parse(label11.Text);
                    int i = da.Deletemovei(s);
                    if (i > 0)
                    {


                        {
                            MessageBox.Show("Succesfully Deleted");
                            dt = da.allmovie(s);
                            dataGridView1.DataSource = dt;

                        }
                    }
                    else
                    {
                        MessageBox.Show("Server busy");
                    }
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;

            label11.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        }
    }
}
