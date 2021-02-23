using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClasses
{
    internal class Teacher
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        static string Myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        private SqlConnection conn;

        public DataTable Select()
        {
            SqlConnection conn = new SqlConnection(Myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM Teacher WHERE ID=@ID OR Name=@Name ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@Name", Name);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            } catch (Exception ex){
            }finally
            {
                conn.Close();
            }
            return dt;
        }

        public bool insert(Teacher c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(Myconnstrng);
            try
            {
                string sql = "INSERT INTO Teacher (ID, Name, Number) VALUES (@ID, @Name, @Number)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ID", c.ID);
                cmd.Parameters.AddWithValue("@Name", c.Name);
                cmd.Parameters.AddWithValue("@Number", c.Number);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0) {isSuccess = true; }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex){
            }finally
            {
                conn.Close();
            }
            return isSuccess;
        }

        public bool Update(Teacher c)
        {
            bool isSuccess = false;
            try {
                String sql = "UPDATE Teacher SET Name=@Name, Number=@Number WHERE ID=@ID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Number", Number);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if(rows>0) { isSuccess = true; } else { isSuccess = false; }
            } catch(Exception ex) {
            } finally
            {
                conn.Close();
            }
            return isSuccess;

        }

        public bool Delete(Teacher c)
        {
            bool isSuccess = false;
            try
            {
                string sql = "DELETE FROM Teacher WHERE ID=@ID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ID", c.ID);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0) { isSuccess = true; } else { isSuccess = false; }
            }
            catch(Exception ex){
            }finally
            {
                conn.Close();
            }
            return isSuccess;
        }
    }
}
