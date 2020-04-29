using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS
{
    public partial class Assesmentmarks : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DSAICJG;Initial Catalog=LMS;Integrated Security=True");
        String Id;
        String sqlQuery;

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
            
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            if (Request.QueryString["Name"] != null)
            {
                Id = Request.QueryString["Name"];
                sqlQuery = "Select CONCAT(FName,LName) from Student where " + Id + " = StudentId";
                cmd.CommandText = sqlQuery;
                cmd.Connection = conn;
                string Name = (String)cmd.ExecuteScalar();
                TextBox1.Text = Name;
                TextBox2.Text = Id; sqlQuery = "Select Session from Student where " + Id + " = StudentId";
                cmd.CommandText = sqlQuery;
                cmd.Connection = conn;
                string Semester = (String)cmd.ExecuteScalar();
                TextBox3.Text = Semester;
            }
            Fill_Box(sender, e);
        }
        protected void Fill_Box(object sender, EventArgs e) {
            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            sqlQuery = "Select c.CourseName from StudentCourse sc,Course c, Section s,Faculty f where f.CourseId = sc.CourseId and c.CourseId = sc.CourseId and sc.SectionId = s.SectionId  and sc.StudentId = 1 and sc.Status = 1";
            cmd.CommandText = sqlQuery;
            cmd.Connection = conn;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) {
                ListItem list = new ListItem();
                list.Text = reader[0] +" ";
                Subjects.Items.Add(list);
            }
        }
        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("Marks.aspx?Name=" + TextBox2.Text + "&course=" + Subjects.SelectedValue);
        }

    }




}
