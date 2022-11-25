using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace dbConnCore.Pages
{
    public class AdminModel : PageModel
    { 
            public void OnPost()
            {
                try
                {
                    Admin_details info = new Admin_details();
                    Console.WriteLine("Check");
                    string ConnectionString = "Data Source=INLPF21DWCZ\\MSSQLSERVER02;Initial Catalog=master;trusted_connection=true";
                    SqlConnection sqlCon = new SqlConnection(ConnectionString);



                    info.c_email = Request.Form["email"];
                   info.c_pass = Request.Form["psw"];



                    sqlCon.Open();



                   


                   
                  



                    sqlCon.Close();
                    Console.WriteLine(info.c_pass + " " + info.c_pass);
                    if (info.c_pass =="jyothi" && info.c_email=="jyothii@gmail.com" )
                    {
                        Console.WriteLine("Admin entered Success");
                        Response.Redirect("/ResidentsDetail");
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

        public class Admin_details
        {
            public int a_id;
            public string c_name, c_email, c_pass;
            public long c_p_no;





        }

    }
