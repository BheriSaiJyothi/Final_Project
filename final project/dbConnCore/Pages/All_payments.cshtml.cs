using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using System.Data.SqlClient;

namespace dbConnCore.Pages
{
    public class All_paymentsModel : PageModel
    {




        public List<all_payments>  payment1 = new List<all_payments>();

        public void OnGet()
        {
            try
            {
                string connection = "Data Source=INLPF21DWCZ\\MSSQLSERVER02;Initial Catalog=master;trusted_connection=true";
                //string connection1 = _configuration.GetConnectionString("DefaultConnection");
                SqlConnection conn = new SqlConnection(connection);
                conn.Open();


                SqlCommand cmd = new SqlCommand("print_details", conn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                   all_payments ji = new all_payments();
                    ji.name = reader.GetString(0);
                    ji.paid_date = reader.GetDateTime(1);
                    ji.status = reader.GetString(2);
                    ji.amount = reader.GetInt64(3);




                    payment1.Add(ji);


                }

                //stu_list.ForEach(x => Console.WriteLine(x.s_id + " " + x.s_name + " " + x.month_name + " " + x.course_name+" "+x.e_mail));
                conn.Close();
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
        

    }

    public class all_payments
    {

        public string name;
       
        public DateTime paid_date;
        public string status;
      public   long amount; 



    }
}

