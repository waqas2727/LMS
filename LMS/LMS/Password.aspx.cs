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
    public partial class Setting : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DSAICJG;Initial Catalog=LMS;Integrated Security=True");
        String Id;
        String sqlQuery;
        String newpass;

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
            Label1.Visible = false;
            
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
                TextBox2.Text = Id;
                sqlQuery = "Select Session from Student where " + Id + " = StudentId";
                cmd.CommandText = sqlQuery;
                cmd.Connection = conn;
                string Semester = (String)cmd.ExecuteScalar();
                TextBox3.Text = Semester;
                conn.Close();
            }
        }
        protected void Button6_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            sqlQuery = "Select Passwords from Student where " + Id + " = StudentId";
            cmd.CommandText = sqlQuery;
            cmd.Connection = conn;
            string _password = (String)cmd.ExecuteScalar();
            String password = TextBox5.Text;
                if (password.Equals(_password) && TextBox7.Text.Equals(TextBox7.Text))
                {
                newpass = TextBox7.Text;                
                sqlQuery = "update Student set Passwords=@newpass where StudentId=@Id";
                SqlCommand cmd2 = new SqlCommand(sqlQuery, conn);
                cmd2.Parameters.Add("Id", SqlDbType.VarChar).Value = Id;
                cmd2.Parameters.Add("newpass",SqlDbType.VarChar).Value=newpass;
                cmd2.Connection = conn;
                cmd2.ExecuteNonQuery();
                Label1.Text = "Passwords Upadate Sucessfully";
                Label1.Visible = true;
                }
                else
                {
                    Label1.Text = "Wrong Old Password";
                    Label1.Visible = true;
                }
        }

    }
}