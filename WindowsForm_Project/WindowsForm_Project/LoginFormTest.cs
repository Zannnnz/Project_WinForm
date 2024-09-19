using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm_Project
{
    public partial class LoginFormTest : Form
    {
        public LoginFormTest()
        {
            InitializeComponent();
        }

        private void LoginFormTest_Load(object sender, EventArgs e)
        {
           
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (textusername.Text == "BiuBiu" && textpassword.Text == "2309")
            {
                errormess.Visible = false;
                Dashboard ds = new Dashboard();
                this.Hide();
                ds.Show();
            }
            else
            {
                errormess.Visible = true;
                textusername.Clear();
                textpassword.Clear();
            }
        }
        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
