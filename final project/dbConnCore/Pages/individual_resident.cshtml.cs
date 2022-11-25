using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System;
namespace dbConnCore.Pages
{
    public class individual_residentModel : PageModel
    {
        public List<Resident22> resident = new List<Resident22>();
        Resident22 jii = new Resident22();
        public void OnGet()
        {
            try
            {

                jii.Resident_Email = Request.Query["Resident_Email"];
                Console.WriteLine(jii.Resident_Email);



                string connection = "Data Source=INLPF21DWCZ\\MSSQLSERVER02;Initial Catalog=master;trusted_connection=true";
            //string connection1 = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();

            SqlCommand cmd = new SqlCommand("individual_resident", conn);
                cmd.Parameters.Add("@Resident_Email", System.Data.SqlDbType.VarChar).Value = jii.Resident_Email;

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

            //cmd.ExecuteNonQuery();

            SqlDataReader reader = cmd.ExecuteReader();

            reader.Read();

            Resident22 s1 = new Resident22();
            s1.Resident_Id = reader.GetInt32(0);
            s1.Resident_Name = reader.GetString(1);
            s1.Resident_Email = reader.GetString(2);
            s1.Resident_Phone = reader.GetInt64(3);
            s1.Resident_Date = reader.GetDateTime(4);
            s1.Resident_Password = reader.GetString(5);

            resident.Add(s1);




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
        
    
public class Resident22
{
    public int Resident_Id;
    public string Resident_Name, Resident_Email;
    public long Resident_Phone;
    public DateTime Resident_Date;
    public long Resident_Due;
    public string Resident_Password;


}
}
