using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using static dbConnCore.Pages.Shared.Apartment_DetailModel;

namespace dbConnCore.Pages
{
    public class Add_ApartmentModel : PageModel
    {
        Apartments s1 = new Apartments();
        public string success_msg = "";
        public string error_msg = "";

        public void OnPost()
        {
           

            try
            {
                string connection = "Data Source=INLPF21DWCZ\\MSSQLSERVER02;Initial Catalog=master;trusted_connection=true";
                //string connection1 = _configuration.GetConnectionString("DefaultConnection");
                SqlConnection conn = new SqlConnection(connection);
                s1.Apartment_Id = Convert.ToInt32(Request.Form["Apartment_Id"]);
               
                conn.Open();
                SqlCommand jo = new SqlCommand("Add_Apartments", conn);
                jo.CommandType = System.Data.CommandType.StoredProcedure;
                jo.Parameters.Add("@a_id", System.Data.SqlDbType.Int).Value = s1.Apartment_Id;


                jo.ExecuteNonQuery();
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
