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
    public partial class Sellinfo : Form
    {
        public Sellinfo()
        {
            InitializeComponent();
        }
        Ticket s = new Ticket();
        DataAccess da = new DataAccess();
        DataTable dt = new DataTable();
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxUname_TextChanged(object sender, EventArgs e)
        {
            s.showname = textBoxUname.Text;

            dt = da.sellinfosearch(s);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Sellinfo_Load(object sender, EventArgs e)
        {
            dt = da.sellinfo(s);
            dataGridView1.DataSource = dt;
        }
    }
}
