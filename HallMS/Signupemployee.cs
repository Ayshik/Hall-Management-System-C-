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
    public partial class Signupmanager : Form
    {
        public Signupmanager()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        Login s = new Login();
        DataAccess da = new DataAccess();
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxUname.Text == "" || textBoxPass.Text == "" || textBox3.Text == "" || textBoxMobile.Text == "" || comboBox1.Text == "Please select a question!" || textBox2.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Please fill all the information");
            }
            else
            {
                s.name = textBoxUname.Text;
                s.Password = textBoxPass.Text;

                s.phone = textBoxMobile.Text;
                s.address = textBox1.Text;
                s.email = textBox3.Text;
                s.ques = comboBox1.Text;
                s.ans = textBox2.Text;



                int i = da.CreateAccountemployee(s);
                if (i > 0)
                {
                    MessageBox.Show("Account Created");
                }
                else
                {
                    MessageBox.Show("opss server is Busy");
                }
            }



            s.name = textBoxUname.Text;
            s.Password = textBoxPass.Text;
            s.phone = textBoxMobile.Text;
            s.ans = textBox2.Text;
            dt = da.fetchid(s);

            if (dt.Rows.Count == 1)
            {


                label11.Text= dt.Rows[0][0].ToString();
               
                label10.Visible = true;
                label11.Visible = true;

            }
        }
    }
}