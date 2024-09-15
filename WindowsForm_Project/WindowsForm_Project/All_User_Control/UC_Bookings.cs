using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsForm_Project.Models;
using System.Data.SqlClient;

namespace WindowsForm_Project.All_User_Control
{
    public partial class UC_Bookings : UserControl
    {
        public UC_Bookings()
        {
            InitializeComponent();
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }

        private bool ValidateInput()
        {
            if(txtmaphong.Text == "" || txtsophong.Text == "" || txtloaiphong.SelectedItem == null || txtloaigiuong.SelectedItem == null || txtgia.Text == "")
            {
                MessageBox.Show("Please fill in all the fields.");
                return false;
            }
            return true;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                Room room = new Room
                {
                    maphong = int.Parse(txtmaphong.Text),
                    roomnumber = int.Parse(txtsophong.Text),
                    roomtype = txtloaiphong.SelectedItem.ToString(),
                    numbed = int.Parse(txtloaigiuong.SelectedItem.ToString()),
                    price = int.Parse(txtgia.Text)
                };

                DAL dal = new DAL();
                string connectionString = "Server=BIUUUBIUUU\\MSSQLSERVER02;Initial Catalog=Hotel_Management;User ID=sa;Password=1201;TrustServerCertificate=True;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    Response response = dal.Addroom(room, conn);
                    MessageBox.Show(response.statusmessage);
                }
            }
        }
    }
}
