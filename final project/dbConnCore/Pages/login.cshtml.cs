using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace dbConnCore.Pages
{
    public class loginModel : PageModel
    {
        public void OnPost()
        {
            try
            {
                Customer_info info = new Customer_info();
                Console.WriteLine("Check");
                string ConnectionString = "Data Source=INLPF21DWCZ\\MSSQLSERVER02;Initial Catalog=master;trusted_connection=true";
                SqlConnection sqlCon = new SqlConnection(ConnectionString);



                info.c_email = Request.Form["email"];
                string temp_pass = Request.Form["psw"];


                Console.WriteLine("Login page: " + info.c_email);
                sqlCon.Open();



                SqlCommand cmd = new SqlCommand("logins", sqlCon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;



                cmd.Parameters.Add("@Resident_Email", System.Data.SqlDbType.VarChar).Value = info.c_email;



                cmd.ExecuteNonQuery();



                SqlDataReader reader = cmd.ExecuteReader();



                reader.Read();
                info.c_pass = reader.GetString(0);



                sqlCon.Close();
                Console.WriteLine(temp_pass + " " + info.c_pass);
                if (temp_pass == info.c_pass)
                {
                    Console.WriteLine("Login Success");
                    Response.Redirect("/individual_resident?Resident_Email="+ info.c_email);
                }
                else
                {
                    Console.WriteLine("Login Failed");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Sql related problem: ");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("C# related problem: ");
                Console.WriteLine(ex.Message);
            }
        }
    }

    public class Customer_info
    {
        public int c_id;
        public string c_name, c_email, c_pass;
        public long c_p_no;





    }

} 

