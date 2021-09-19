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
    public partial class Forgetpass : Form
    {
        public Forgetpass()
        {
            InitializeComponent();
        }
        DataAccess da = new DataAccess();

        Login l = new Login();
        DataTable dt = new DataTable();
        Boolean state = false;
        private void Forgetpass_Load(object sender, EventArgs e)
        {

        }

        private void ownersignupback_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Visible = true;
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBoxUname.Text == "")
            { MessageBox.Show("please enter your userid"); }
            else
            {
                l.Userid = textBoxUname.Text;
                {
                    if (state == false)
                    {
                        dt = da.forgetman(l);

                        if (dt.Rows.Count == 1)
                        {
                            state = true;
                            label8.Visible = false;
                            textBoxUname.Visible = false;
                            button2.Visible = false;
                            label2.Visible = true;
                            label3.Visible = true;
                            button3.Visible = true;
                            button4.Visible = true;
                            label2.Text = dt.Rows[0][1].ToString();
                            label4.Text = dt.Rows[0][6].ToString();
                            label7.Text = dt.Rows[0][7].ToString();
                            label6.Text = dt.Rows[0][5].ToString();
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
                        dt = da.forgetem(l);

                        if (dt.Rows.Count == 1)
                        {
                            state = true;
                            label8.Visible = false;
                            textBoxUname.Visible = false;
                            button2.Visible = false;
                            label2.Visible = true;
                            label3.Visible = true;
                            button3.Visible = true;
                            button4.Visible = true;
                            label2.Text = dt.Rows[0][1].ToString();
                            label4.Text = dt.Rows[0][7].ToString();
                            label7.Text = dt.Rows[0][8].ToString();
                            label6.Text = dt.Rows[0][6].ToString();

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

        private void button4_Click(object sender, EventArgs e)
        {
            Forgetpass fp = new Forgetpass();
            this.Visible = false;
            fp.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label4.Visible = true;
            textBoxMobile.Visible = true;
            button1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxMobile.Text == "") { MessageBox.Show("please enter your Answer"); }
            else
            {
                if (textBoxMobile.Text == label7.Text)
                {
                    label5.Visible = true;
                    label6.Visible = true;


                }
                else
                {
                    MessageBox.Show("This is not the correct Answer,try Again");
                    Forgetpass fp = new Forgetpass();
                    this.Visible = false;
                    fp.Visible = true;

                }
            }
        }
    }
    }

