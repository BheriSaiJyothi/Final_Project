using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace dbConnCore.Pages.Shared
{
    public class Apartment_DetailModel : PageModel
    {
        public List<Apartments> ap = new List<Apartments>();
        public void OnGet()
        {


            try
            {
                string connection = "Data Source=INLPF21DWCZ\\MSSQLSERVER02;Initial Catalog=master;trusted_connection=true";
                //string connection1 = _configuration.GetConnectionString("DefaultConnection");
                SqlConnection conn = new SqlConnection(connection);
                conn.Open();

                SqlCommand jo = new SqlCommand("Apartment_Details", conn);
                jo.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader ji = jo.ExecuteReader();
                while (ji.Read())
                {
                    Apartments s1 = new Apartments();
                    s1.Apartment_Id = ji.GetInt32(0);
                    s1.Apartment_Type = ji.GetString(1);

                    s1.Apartment_Name = ji.GetString(2);
                    ap.Add(s1);


                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Sql Related Issue");
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
                Console.WriteLine("C# related Issue");
            }

        }
        public class Apartments
        {
            public string Apartment_Type;
            public string Apartment_Name;
            public int  Apartment_Id;
        }
    }
}
