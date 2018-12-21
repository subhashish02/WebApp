using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using WebApp.Models;

namespace WebApp.DataUtility
{
    public class StudentUtility
    {
        public static List<Student> GetAllStudent()
        {
            List<Student> ls = new List<Student>();
            //string connstr = ConfigurationManager.ConnectionStrings["mysqlConnString"].ConnectionString;
            using (MySqlConnection scon = new MySqlConnection(ConfigurationManager.ConnectionStrings["mysqlConnString"].ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("SELECT stud.rollno, stud.sname, stud.sage, stud.sgender, stud.sdob, marks.maxmarks, marks.phy, marks.chem, marks.math, marks.bio FROM stud INNER JOIN marks ON stud.rollno=marks.rollno;", scon);
                try
                {
                    scon.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Student student = new Student();
                        student.rollno = Convert.ToInt32(reader["rollno"]);
                        student.sname = reader["sname"].ToString();
                        student.sage = Convert.ToInt32(reader["sage"]);
                        student.sgender = reader["sgender"].ToString();
                        student.sdob = Convert.ToDateTime(reader["sdob"]);
                        student.maxmarks = Convert.ToInt32(reader["maxmarks"]);
                        //student.marksobt = Convert.ToInt32(reader["marksobt"]);
                        student.phy = Convert.ToInt32(reader["phy"]);
                        student.chem = Convert.ToInt32(reader["chem"]);
                        student.math = Convert.ToInt32(reader["math"]);
                        student.bio = Convert.ToInt32(reader["bio"]);
                        ls.Add(student);
                    }
                }
                catch (Exception e)
                {
                    
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                    if (scon.State == System.Data.ConnectionState.Open)
                    {
                        scon.Close();
                    }

                }
                return ls;

            }

        }

        internal static string CreateStudent(Student value)
        {
            String cs = ConfigurationManager.ConnectionStrings["mysqlConnString"].ConnectionString;
            MySqlConnection scon = new MySqlConnection(cs);
            MySqlCommand scmd = scon.CreateCommand();
            scmd.CommandText = "INSERT INTO stud (sname, sage, sgender, sdob) VALUES (@sname, @sage, @sgender, @sdob)";
            scmd.Parameters.AddWithValue("@sname", value.sname);
            scmd.Parameters.AddWithValue("@sage", value.sage);
            scmd.Parameters.AddWithValue("@sgender", value.sgender);
            scmd.Parameters.AddWithValue("@sdob", value.sdob);
            scon.Open();
            scmd.ExecuteNonQuery();
            scon.Close();
            scmd.CommandText = "INSERT INTO marks (maxmarks, phy, chem, math, bio) VALUES (@maxmarks, @phy, @chem, @math, @bio)";
            scmd.Parameters.AddWithValue("@maxmarks", value.maxmarks);
            scmd.Parameters.AddWithValue("@phy", value.phy);
            scmd.Parameters.AddWithValue("@chem", value.chem);
            scmd.Parameters.AddWithValue("@math", value.math);
            scmd.Parameters.AddWithValue("@bio", value.bio);
            scon.Open();
            scmd.ExecuteNonQuery();
            scon.Close();
            return cs;
        }
    }
}
