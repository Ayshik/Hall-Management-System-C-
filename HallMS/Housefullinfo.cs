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
    public partial class Housefullinfo : Form
    {
        public Housefullinfo()
        {
            InitializeComponent();
        }
        movie s = new movie();
        DataAccess da = new DataAccess();
        DataTable dt = new DataTable();
        private void textBoxUname_TextChanged(object sender, EventArgs e)
        {
            s.showname = textBoxUname.Text;

            dt = da.housefulllistsearch(s);
            dataGridView1.DataSource = dt;
        }

        private void Housefullinfo_Load(object sender, EventArgs e)
        {
            dt = da.housefulllist(s);
            dataGridView1.DataSource = dt;
        }
    }
}
