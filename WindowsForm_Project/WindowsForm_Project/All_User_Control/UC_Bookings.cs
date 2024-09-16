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
            if(txtmaphong.Text == "" || txtsophong.Text == "" || txtloaiphong.SelectedItem == null || txtloaigiuong.SelectedItem == null || inputdateci.Value == null || inputdateco.Value == null || txtgia.Text == "")
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
                    date_ci = inputdateci.Value,
                    date_co = inputdateco.Value,
                    price = int.Parse(txtgia.Text)
                };

                DAL dal = new DAL();
                string connectionString = "Server=BIUUUBIUUU\\MSSQLSERVER02;Initial Catalog=Hotel_Management;User ID=sa;Password=1201;TrustServerCertificate=True;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    Response response = dal.Addroom(room, conn);
                    MessageBox.Show(response.statusmessage);
                    if (response.statusmessage.Contains("successfully"))
                    {
                        RefreshControl();
                    }
                }
            }
        }

        private void RefreshControl()
        {
            clearAll();
            LoadRoomData();
        }

        public void clearAll()
        {
            txtmaphong.Clear();
            txtsophong.Clear();
            txtloaiphong.SelectedIndex = -1;
            txtloaigiuong.SelectedIndex = -1;
            inputdateci.Value = DateTime.Now;
            inputdateco.Value = DateTime.Now;
            txtgia.Clear();
        }

        private void UC_Bookings_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private void UC_Bookings_Enter(object sender, EventArgs e)
        {
            try
            {
                LoadRoomData();
                DataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading room data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRoomData()
        {
            DAL dal = new DAL();
            string connectionString = "Server=BIUUUBIUUU\\MSSQLSERVER02;Initial Catalog=Hotel_Management;User ID=sa;Password=1201;TrustServerCertificate=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                Response response = dal.Getroom(conn);
                if (response.list != null && response.list.Count > 0)
                {
                    DataGridView1.DataSource = null; // Clear previous data
                    DataGridView1.DataSource = response.list;
                    DataGridView1.Refresh(); // Refresh the grid view
                }
                else
                {
                    MessageBox.Show("No room data available or " + response.statusmessage);
                }
            }
        }

        private void UC_Bookings_Load(object sender, EventArgs e)
        {

        }

        private void txtsophong_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        private void txtloaigiuong_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
