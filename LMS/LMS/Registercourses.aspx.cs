using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS
{
    public partial class Courses : System.Web.UI.Page
    {
        String Id;
        String sqlQuery;
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DSAICJG; Initial Catalog = LMS; Integrated Security = True");

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
            SqlConnection conn2 = new SqlConnection(@"Data Source=DESKTOP-DSAICJG;Initial Catalog=LMS;Integrated Security=True");

            conn2.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            if (Request.QueryString["Name"] != null)
            {
                Id = Request.QueryString["Name"];
                sqlQuery = "Select CONCAT(FName,LName) from Student where " + Id + " = StudentId";
                cmd.CommandText = sqlQuery;
                cmd.Connection = conn2;
                string Name = (String)cmd.ExecuteScalar();
                TextBox1.Text = Name;
                TextBox2.Text = Id; sqlQuery = "Select Session from Student where " + Id + " = StudentId";
                cmd.CommandText = sqlQuery;
                cmd.Connection = conn2;
                string Semester = (String)cmd.ExecuteScalar();
                TextBox3.Text = Semester;
            }
            using (conn)
            {
                    conn.Open();
                    SqlDataAdapter sqDa = new SqlDataAdapter("Select c.CourseName ,c.CeditHours,CONCAT(f.FName,f.LName) as Instructor,s.Section from StudentCourse sc,Course c,Section s,Faculty f where f.CourseId = sc.CourseId and c.CourseId = sc.CourseId and sc.SectionId = s.SectionId  and sc.StudentId ='" + @Id + "'" +"and sc.Status =1", conn);
                    DataTable dtbl = new DataTable();
                    sqDa.Fill(dtbl);
                    Student.DataSource = dtbl;
                    Student.DataBind();
            }
            conn.Close();
            

        }
    }
}