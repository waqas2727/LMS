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
    public partial class Marks : System.Web.UI.Page
    {
        String Id;
        String sqlQuery;
        string CourseId;
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
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            if (Request.QueryString["Name"] != null)
            {
                Id = Request.QueryString["Name"];
                sqlQuery = "Select CONCAT(FName,' ',LName) from Student where " + Id + " = StudentId";
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
            Label1.Visible = false;
            SqlConnection conn2 = new SqlConnection(@"Data Source=DESKTOP-DSAICJG;Initial Catalog=LMS;Integrated Security=True");
            conn2.Open();
            SqlCommand cmd2 = new SqlCommand();
            cmd2.CommandType = CommandType.Text;
            if (Request.QueryString["course"] != null) { 
            String Code = Request.QueryString["course"];
            String sqlQuery1 = "Select c.CourseId from Course c where c.CourseName=@Code";
            cmd2.Parameters.AddWithValue("@Code",Code);
            cmd2.CommandText = sqlQuery1;
            cmd2.Connection = conn2;
            CourseId = (String)cmd2.ExecuteScalar();
                TextBox4.Text = Code;
            }
            SqlConnection conn3 = new SqlConnection(@"Data Source=DESKTOP-DSAICJG;Initial Catalog=LMS;Integrated Security=True");
            conn3.Open();
            using (conn3)
            {
                String sqlQuery3 = "Select Dates,TotalMarks,ObatinMarks from AssesmentMarks  where AssessmentType=1 and StudentId='" + @Id+"'" + "and CourseId='" + @CourseId + "'" ;
                SqlDataAdapter sqDa = new SqlDataAdapter(sqlQuery3, conn);
                DataTable dtbl = new DataTable();
                sqDa.Fill(dtbl);
                Quiz.DataSource = dtbl;
                Quiz.DataBind();
            }
            SqlConnection conn4 = new SqlConnection(@"Data Source=DESKTOP-DSAICJG;Initial Catalog=LMS;Integrated Security=True");
            conn4.Open();
            using (conn4)
            {
                String sqlQuery4 = "Select Dates,TotalMarks,ObatinMarks from AssesmentMarks  where AssessmentType=2 and StudentId='" + @Id + "'" + "and CourseId='" + @CourseId + "'";
                SqlDataAdapter sqDa2 = new SqlDataAdapter(sqlQuery4, conn);
                DataTable dtbl1 = new DataTable();
                sqDa2.Fill(dtbl1);
                Assignment.DataSource = dtbl1;
                Assignment.DataBind();
            }
            using (conn)
            {
                String sqlQuery5 = "Select Dates,TotalMarks,ObatinMarks from AssesmentMarks  where AssessmentType=3 and StudentId='" + @Id + "'" + "and CourseId='" + @CourseId + "'";
                SqlDataAdapter sqDa3 = new SqlDataAdapter(sqlQuery5, conn);
                DataTable dtbl2 = new DataTable();
                sqDa3.Fill(dtbl2);
                Exam.DataSource = dtbl2;
                Exam.DataBind();
            }


        }
    }
}