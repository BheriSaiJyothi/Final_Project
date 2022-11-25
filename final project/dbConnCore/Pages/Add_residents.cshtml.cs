using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace dbConnCore.Pages
{
    public class Add_residentsModel : PageModel
    {

        public Resident1 s = new Resident1();
        public string success_msg = "";
        public string error_msg = "";
        public void OnPost()
        {
            
            try
            {
                string connection = "Data Source=INLPF21DWCZ\\MSSQLSERVER02;Initial Catalog=master;trusted_connection=true";
                //string connection1 = _configuration.GetConnectionString("DefaultConnection");
                SqlConnection conn = new SqlConnection(connection);
                s.Resident_Id = Convert.ToInt32(Request.Form["Resident_Id"]);
                s.Resident_Name = Request.Form["Resident_Name"];
                s.Resident_Email= Request.Form["Resident_Email"];
                s.Resident_Phone = Convert.ToInt64(Request.Form["Resident_Phone"]);
                s.Resident_Date = Convert.ToDateTime(Request.Form["Resident_Date"]);
                s.Resident_Password= Request.Form["Resident_Password"];



                conn.Open();


                SqlCommand cmd = new SqlCommand("Add_Resident", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
              

                cmd.Parameters.Add("@Resident_Id", System.Data.SqlDbType.Int).Value = s.Resident_Id;
                cmd.Parameters.Add("@Resident_Name", System.Data.SqlDbType.VarChar).Value = s.Resident_Name;
                cmd.Parameters.Add("@Resident_Email", System.Data.SqlDbType.VarChar).Value = s.Resident_Email;
                cmd.Parameters.Add("@Resident_Phone", System.Data.SqlDbType.BigInt).Value = s.Resident_Phone;
                cmd.Parameters.Add("@Resident_Date", System.Data.SqlDbType.DateTime).Value = s.Resident_Date;
                cmd.Parameters.Add("@Resident_Password", System.Data.SqlDbType.VarChar).Value = s.Resident_Password;
               
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Sql Related Issue");
                error_msg = "Error -sql problem";
                return;
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
                Console.WriteLine("C# related Issue");
                return;
            }
            success_msg = "Successfully Added";
           
        }
    }
}
