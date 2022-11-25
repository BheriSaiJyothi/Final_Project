using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace dbConnCore.Pages
{
    public class ResidentsDetailModel : PageModel
    {
        public List<Resident1> resident = new List<Resident1>();

        public void OnGet()
        {
            try
            {
                string connection = "Data Source=INLPF21DWCZ\\MSSQLSERVER02;Initial Catalog=master;trusted_connection=true";
                //string connection1 = _configuration.GetConnectionString("DefaultConnection");
                SqlConnection conn = new SqlConnection(connection);
                conn.Open();

                SqlCommand cmd = new SqlCommand("Resident_Details", conn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //SqlCommand jo = new SqlCommand("Apartment_Details", conn);
                //  jo.CommandType = System.Data.CommandType.StoredProcedure;
                //SqlDataReader ji = jo.ExecuteReader();
                //while (ji.Read())
                //{
                //    Resident1 s1 = new Resident1();

                //    s1.Apartment_Type = ji.GetString(0);

                //    s1.Apartment_Name = ji.GetString(1);



                //}
                //cmd.ExecuteNonQuery();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Resident1 s1 = new Resident1();
                    s1.Resident_Id= reader.GetInt32(0);
                    s1.Resident_Name = reader.GetString(1);
                    s1.Resident_Email = reader.GetString(2);
                    s1.Resident_Phone = reader.GetInt64(3);
                    s1.Resident_Date = reader.GetDateTime(4);
                    s1.Resident_Password = reader.GetString(5);


                    resident.Add(s1);


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
        /*public void Delete_Student(int StudentID)
        {
            try
            {
                string connection = "Data Source=INLPF2RXRDD\\MSSQLSERVER1;Initial Catalog=master;trusted_connection=true";
                //string connection1 = _configuration.GetConnectionString("DefaultConnection");
                SqlConnection conn = new SqlConnection(connection);
                conn.Open();

                SqlCommand cmd = new SqlCommand("delete_student", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                *//*STUDENTS s2=new STUDENTS();
                s2.s_id = StudentID;*//*

                cmd.Parameters.Add("@sid", System.Data.SqlDbType.Int).Value = StudentID;
                Console.WriteLine(StudentID);

                cmd.ExecuteNonQuery();

                

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
    }*/

    }

        public class Resident1
        {
        public int Resident_Id;
            public string Resident_Name, Resident_Email;
        public long Resident_Phone;
        public DateTime Resident_Date;
        public string Resident_Password;
        


        }
    }
