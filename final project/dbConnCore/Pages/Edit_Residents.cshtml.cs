using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;

namespace dbConnCore.Pages
{
    public class Edit_ResidentsModel : PageModel
    {

        public List<Resident1> list_name = new List<Resident1>();
        public Resident1  update = new Resident1();
        public string success_msg = "";
        public string error_msg = "";
        public void OnGet()
        {

            try
            {
                update.Resident_Id = Convert.ToInt32(Request.Query["Resident_Id"]);

                

                string ConnectionString = "Data Source=INLPF21DWCZ\\MSSQLSERVER02;Initial Catalog=master;trusted_connection=true";
                
                SqlConnection sqlCon = new SqlConnection(ConnectionString);
                sqlCon.Open();
                string query = "select Resident_Name,  Resident_Email ,Resident_Phone ,  Resident_Date , Resident_Password from residents   where Resident_Id= @Resident_Id";


                SqlCommand cmd = new SqlCommand(query, sqlCon);

               cmd.Parameters.Add("@Resident_Id", System.Data.SqlDbType.Int).Value = update.Resident_Id;
                
                
                //cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    
                    update.Resident_Name = reader.GetString(0);
                
                    update.Resident_Email = reader.GetString(1);
                    update.Resident_Phone= reader.GetInt64(2);
                    update.Resident_Date = reader.GetDateTime(3);
                  
                    update.Resident_Password = reader.GetString(4);

                    list_name.Add(update);


                }
                list_name.ForEach(x => Console.WriteLine(x.Resident_Id + " " + x.Resident_Name+ " " + x.Resident_Email + " " + x.Resident_Phone + " " + x.Resident_Date + " " + x.Resident_Password));

                //Console.Log(list_name);
                sqlCon.Close();
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
           
        }

        public void OnPost()
        {
            try
            {
                // update.s_id = Convert.ToInt32(Request.Query["id"]);
                
                string connection = "Data Source=INLPF21DWCZ\\MSSQLSERVER02;Initial Catalog=master;trusted_connection=true";
                //string connection1 = _configuration.GetConnectionString("DefaultConnection");
                SqlConnection conn = new SqlConnection(connection);
               update.Resident_Id = Convert.ToInt32(Request.Form["Resident_Id"]);
                update.Resident_Name = Request.Form["Resident_Name"];
               // update.s_name = Request.Query["name"];
                update.Resident_Email = Request.Form["Resident_Email"];
                update.Resident_Phone = Convert.ToInt64(Request.Form["Resident_Phone"]);
                update.Resident_Date = Convert.ToDateTime(Request.Form["Resident_Date"]);
              
                update.Resident_Password= Request.Form["Resident_Password"];
                Console.WriteLine(update.Resident_Id+update.Resident_Name + update.Resident_Email+ update.Resident_Phone+ update.Resident_Date);


                conn.Open();


                SqlCommand cmd = new SqlCommand("update_resident", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add("@Resident_Id", System.Data.SqlDbType.Int).Value = update.Resident_Id;
                cmd.Parameters.Add("@Resident_Name", System.Data.SqlDbType.VarChar).Value = update.Resident_Name;
                cmd.Parameters.Add("@Resident_Email", System.Data.SqlDbType.VarChar).Value = update.Resident_Email;
                cmd.Parameters.Add("@Resident_Phone", System.Data.SqlDbType.BigInt).Value = update.Resident_Phone;
                cmd.Parameters.Add("@Resident_Date", System.Data.SqlDbType.DateTime).Value = update.Resident_Date;
                cmd.Parameters.Add("@Resident_Password", System.Data.SqlDbType.VarChar).Value = update.Resident_Password;


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
