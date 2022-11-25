using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace dbConnCore.Pages
{
    public class PaymentModel : PageModel
    {


        public void OnPost()
        {
            try
            {
                payment_details y = new payment_details();
                Console.WriteLine("Check");
                string ConnectionString = "Data Source=INLPF21DWCZ\\MSSQLSERVER02;Initial Catalog=master;trusted_connection=true";
                SqlConnection sqlCon = new SqlConnection(ConnectionString);



               y.name= Request.Form["name"];
                y.date = Convert.ToDateTime(Request.Form["p_date"]);
                y.status = Request.Form["status"];
                y.amount = Convert.ToInt64(Request.Form["amount"]);

                sqlCon.Open();



                //SqlCommand cmd = new SqlCommand("update_payments", sqlCon);
                //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //cmd.Parameters.Add("@Resident_Name", System.Data.SqlDbType.VarChar).Value = y.name;
                //cmd.ExecuteNonQuery();



                //SqlDataReader reader = cmd.ExecuteReader();



                //reader.Read();
                SqlCommand jo = new SqlCommand("All_payments", sqlCon);
                jo.CommandType = System.Data.CommandType.StoredProcedure;



               jo.Parameters.Add("@name", System.Data.SqlDbType.VarChar).Value = y.name;
                jo.Parameters.Add("@paid_date", System.Data.SqlDbType.VarChar).Value = y.date;
                jo.Parameters.Add("@status", System.Data.SqlDbType.VarChar).Value = y.status;
                jo.Parameters.Add("@amount", System.Data.SqlDbType.BigInt).Value = y.amount;







                jo.ExecuteNonQuery();



                //SqlDataReader ji = jo.ExecuteReader();



                //ji.Read();
                
                sqlCon.Close();

                // Response.Redirect("/ResidentsDetail");
                Response.Redirect("/resident_history?name=" + y.name);
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

    public class payment_details
    {

        public string name, status;
        public DateTime date;
     public     long amount; 



    }
}
