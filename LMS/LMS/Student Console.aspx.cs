using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.Script.Serialization;
using System.Configuration;
using System.Web.UI.DataVisualization.Charting;

namespace LMS
{
    public partial class Student_Console : System.Web.UI.Page
    {
        String Id;
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registercourses.aspx?Name=" + TextBox2.Text);
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Assesmentmarks.aspx?Name=" + TextBox2.Text);
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Password.aspx?Name=" + TextBox2.Text);
        }
        protected void Button5_Click(object sender, EventArgs e)
        {
            Session.Remove("User_Id");
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DSAICJG;Initial Catalog=LMS;Integrated Security=True");
            
            String sqlQuery;
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            if (Request.QueryString["Name"] != null) {
                Id = Request.QueryString["Name"];
                sqlQuery = "Select CONCAT(FName,LName) from Student where "+Id+" = StudentId";
                cmd.CommandText = sqlQuery;
                cmd.Connection = conn;
                string Name = (String) cmd.ExecuteScalar();
                TextBox1.Text = Name ;
                TextBox2.Text = Id; sqlQuery = "Select Session from Student where " + Id + " = StudentId";
                cmd.CommandText = sqlQuery;
                cmd.Connection = conn;
                string Semester = (String)cmd.ExecuteScalar();
                TextBox3.Text = Semester;
            }

            Chart1_Load(sender, e);
        }

        private void GetChartData()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DSAICJG;Initial Catalog=LMS;Integrated Security=True");
            using (conn)
            {
                conn.Open();
                String sqlQuery = "Select CourseId from StudentCourse where StudentId = 1" ;
                SqlCommand cmd2 = new SqlCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = sqlQuery;
                cmd2.Connection = conn;
                int i = 0;
                String[] code = new string[10]; 
                SqlDataReader reader = cmd2.ExecuteReader();
                while (reader.Read()) {
                    code[i] = reader.GetString(0).Trim();
                    i++;
                }
                i--;
                reader.Close();
                for ( ; i > 0; i--)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand("total", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = 1 ;
                    cmd.Parameters.Add("@CourseId", SqlDbType.VarChar).Value = code[i];

                    SqlDataReader rdr = cmd.ExecuteReader();
                    Series series = Chart1.Series["Series1"];
                    // Loop thru each Student record
                    while (rdr.Read())
                    {

                        // Add X and Y values using AddXY() method
                        series.Points.AddXY(rdr["Result"], rdr["Course_Id"]);

                    }
                }
            }
            
        }
        protected void Chart1_Load(object sender, EventArgs e)
        {
            GetChartData();
        }
    }
}