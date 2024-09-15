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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel7_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel14_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel17_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel19_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel20_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel6_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {

        }

        private void btndashboard_Click(object sender, EventArgs e)
        {
            Panelmoving.Left = btndashboard.Left - 220;
            uC_Dashboard1.Visible = true;
            uC_Dashboard1.BringToFront();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Panelmoving.Left = btndashboard.Left + 200;
            uC_Dashboard1.Visible = false;
            uC_Bookings1.Visible = true;
            uC_Bookings1.BringToFront();
        }

        private void uC_Dashboard1_Load(object sender, EventArgs e)
        {
            uC_Dashboard1.Visible = false;
            btndashboard.PerformClick();
            Panelmoving.Left = btndashboard.Left;
        }

        private void uC_Bookings1_Load(object sender, EventArgs e)
        {
            uC_Dashboard1.Visible = false;
            btndashboard.PerformClick();
            Panelmoving.Left = btndashboard.Left;
        }
    }
}
