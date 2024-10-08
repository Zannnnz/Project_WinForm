using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForm_Project.Models
{
    public class DAL
    {
        public Response Addroom(Room room, SqlConnection conn)
        {
            Response response = new Response();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_addroom", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@maphong", room.maphong);
                cmd.Parameters.AddWithValue("@roomnumber", room.roomnumber);
                cmd.Parameters.AddWithValue("@roomtype", room.roomtype);
                cmd.Parameters.AddWithValue("@numbed", room.numbed);
                cmd.Parameters.AddWithValue("@date_ci", room.date_ci);
                cmd.Parameters.AddWithValue("@date_co", room.date_co);
                cmd.Parameters.AddWithValue("@price", room.price);
                cmd.Parameters.Add("@ErrorMessage", SqlDbType.Char, 200);
                cmd.Parameters["@ErrorMessage"].Direction = ParameterDirection.Output;
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                conn.Close();
                string mess = (string)cmd.Parameters["@ErrorMessage"].Value;
                response.statusmessage = mess;
            }
            catch (Exception ex)
            {
                response.statusmessage = ex.Message;
            }
            return response;
        }
        public Response Getroom(SqlConnection conn)
        {
            Response response = new Response();
            List<Room> list = new List<Room>();
            try
            {
                string query= @"SELECT * FROM Room";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Room room = new Room
                            {
                                maphong = int.Parse(reader["maphong"].ToString()),
                                roomnumber = int.Parse(reader["roomnumber"].ToString()),
                                roomtype = reader["roomtype"].ToString(),
                                numbed = int.Parse(reader["numbed"].ToString()),
                                date_ci = DateTime.Parse(reader["date_ci"].ToString()),
                                date_co = DateTime.Parse(reader["date_co"].ToString()),
                                price = int.Parse(reader["price"].ToString()),
                            };
                            list.Add(room);
                        }
                    }
                }
                response.list = list;
            }
            catch(Exception ex)
            {
                response.statusmessage = ex.Message;
            }
            finally
            {
                if(conn.State == ConnectionState.Open) 
                    conn.Close();
            }
            return response;
        }
        ///DELETE Room
        public Response Addcustomer(Customer customer, SqlConnection conn)
        {
            Response response = new Response();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_addcustomer", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cccd_cus", customer.cccd_cus);
                cmd.Parameters.AddWithValue("@first_name", customer.first_name);
                cmd.Parameters.AddWithValue("@last_name", customer.last_name);
                cmd.Parameters.AddWithValue("@sdt", customer.sdt);
                cmd.Parameters.AddWithValue("@email", customer.email);
                cmd.Parameters.AddWithValue("@gioitinh", customer.gioitinh);
                cmd.Parameters.AddWithValue("@ngaysinh", customer.ngaysinh);
                cmd.Parameters.Add("@ErrorMessage", SqlDbType.Char, 200);
                cmd.Parameters["@ErrorMessage"].Direction = ParameterDirection.Output;
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                conn.Close();
                string mess = (string)cmd.Parameters["@ErrorMessage"].Value;
                response.statusmessage = mess;
            }
            catch (Exception ex)
            {
                response.statusmessage = ex.Message;
            }
            return response;
        }
        public Response Getcustomer(SqlConnection conn)
        {
            Response response = new Response();
            List<Customer> list = new List<Customer>();
            try
            {
                string query = @"SELECT * FROM Customer";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Customer customer = new Customer
                            {
                                cccd_cus = reader["cccd_cus"].ToString(),
                                first_name = reader["first_name"].ToString(),
                                last_name = reader["last_name"].ToString(),
                                sdt = reader["sdt"].ToString(),
                                email = reader["email"].ToString(),
                                gioitinh = reader["gioitinh"].ToString(),
                                ngaysinh = DateTime.Parse(reader["ngaysinh"].ToString()),
                            };
                            list.Add(customer);
                        }
                    }
                }
                response.list1 = list;
            }
            catch (Exception ex)
            {
                response.statusmessage = ex.Message;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return response;
        }
    }
}
