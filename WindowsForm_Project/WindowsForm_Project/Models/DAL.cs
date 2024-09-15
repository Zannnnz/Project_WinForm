using System;
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
    }
}
