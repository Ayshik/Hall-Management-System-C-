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
    public partial class Movielist : Form
    {
        public Movielist()
        {
            InitializeComponent();
        }
        movie s = new movie();
        DataAccess da = new DataAccess();
        DataTable dt = new DataTable();
        private void textBoxUname_TextChanged(object sender, EventArgs e)
        {
            s.showname = textBoxUname.Text;

            dt = da.moviesearch(s);
            dataGridView1.DataSource = dt;

        }

        private void Movielist_Load(object sender, EventArgs e)
        {
            dt = da.movielist(s);
            dataGridView1.DataSource = dt;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
