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
    public partial class Employeeprofile : Form
    {
        public Employeeprofile(string uid)
        {
            InitializeComponent();
            label11.Text = uid;
        }
        Login s = new Login();
        DataTable dt = new DataTable();
        Boolean state = false;
        DataAccess da = new DataAccess();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Employeeprofile_Load(object sender, EventArgs e)
        {
            s.Userid = label11.Text;

            dt = da.profiledata(s);

            if (dt.Rows.Count == 1)
            {

                textBoxUname.Text = dt.Rows[0][1].ToString();
                textBoxPass.Text = dt.Rows[0][6].ToString();
                textBox1.Text = dt.Rows[0][3].ToString();
                textBoxMobile.Text = dt.Rows[0][2].ToString();
                comboBox1.Text = dt.Rows[0][7].ToString();
                textBox2.Text = dt.Rows[0][8].ToString();




            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxUname.Text == "" || textBoxPass.Text == "" || textBox1.Text == "" || textBoxMobile.Text == "" || comboBox1.Text == "Please select a question!" || textBox2.Text == "")
            {
                MessageBox.Show("please Fill information for update");
            }
            else
            {

                s.Userid = label11.Text;
                s.phone = textBoxMobile.Text;
                s.Password = textBoxPass.Text;
                s.address = textBox1.Text;
                s.ques = comboBox1.Text;
                s.ans = textBox2.Text;

                int w = da.employeeupdate(s);
                if (w > 0)
                {
                    MessageBox.Show("Profile updated");
                }

                else { MessageBox.Show("Server busy try again"); }
            }
        }
    }
}