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
            MovePanel(btndashboard);
            uC_Dashboard1.Visible = true;
            uC_Dashboard1.BringToFront();
            // Hide other user controls
            uC_Bookings1.Visible = false;
            // ... hide other user controls
        }

        private void btnBookings_Click(object sender, EventArgs e)
        {
            MovePanel(btnbookings);
            uC_Bookings1.Visible = true;
            uC_Bookings1.BringToFront();
            // Hide other user controls
            uC_Dashboard1.Visible = false;
            // ... hide other user controls
        }

        private void btnCustomerDetail_Click(object sender, EventArgs e)
        {
            MovePanel(btncustomerdetail);
            // Show Customer Detail user control
            // Hide other user controls
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            MovePanel(btncheckout);
            // Show Check Out user control
            // Hide other user controls
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            MovePanel(btnemployee);
            // Show Employee user control
            // Hide other user controls
        }

        private void MovePanel(Guna.UI2.WinForms.Guna2GradientButton clickedButton)
        {
            Panelmoving.Left = clickedButton.Left;
            Panelmoving.Width = clickedButton.Width;
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Panelmoving.Left = btndashboard.Left + 223;
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

        private void Panelmoving_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
