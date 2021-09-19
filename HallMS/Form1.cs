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
    public partial class Form1 : Form
    {
        int w;
        int x = 687, y = 85;
        public Form1()
        {
            InitializeComponent();
        }
        DataAccess da = new DataAccess();
        movie u = new movie();
        Login l = new Login();
        DataTable dt = new DataTable();
        Boolean state = false;

        private void label9_Click(object sender, EventArgs e)
        {
            Forgetpass fp = new Forgetpass();
            fp.Visible = true;
            this.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            w = -722;
            if (w == label4.Left)
            {

                label4.Left = 355;

            }
            else
            {

                int i = -1;
                label4.Left = label4.Left + i++;

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dt = da.Anouncement(u);

            if (dt.Rows.Count == 1)
            {

                label4.Text = dt.Rows[0][0].ToString();

                timer1.Start();


            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (Uname.Text == "" || Pass.Text == "")
            {
                MessageBox.Show("Please Enter username and password");
            }
            else
            {
                l.Userid = Uname.Text;
                l.Password = Pass.Text;



                {
                    if (state == false)
                    {
                        dt = da.Logine(l);

                        if (dt.Rows.Count == 1)
                        {
                            state = true;
                            Employeepanel c = new Employeepanel(Uname.Text);
                            this.Visible = false;
                            c.Visible = true;

                        }
                        else
                        {
                            state = false;
                        }
                    }

                }




                {
                    if (state == false)
                    {
                        dt = da.Loginm(l);

                        if (dt.Rows.Count == 1)
                        {
                            state = true;
                            ManagerPanel i = new ManagerPanel();
                            this.Visible = false;
                            i.Visible = true;

                        }
                        else
                        {
                            state = false;
                        }
                    }

                }




                

                    if (state == false)
                    {
                        MessageBox.Show("Invalid id,No ID found");
                    }



                }

            }
        }
    }

