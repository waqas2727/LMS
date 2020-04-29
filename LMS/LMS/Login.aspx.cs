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
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DSAICJG;
        Initial Catalog=LMS;
        Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            Label.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label.Visible = false;
            String username = UserName.Text;
            String password = TextBox1.Text;
            String id = DropDownList1.SelectedValue;
            String sqlQuery = null;
            conn.Open();

            if (id.Equals("0"))
            {
                sqlQuery = "Select AdminId,Passwords from Admins";
            }
            else if (id.Equals("1"))
            {
                sqlQuery = "Select FacultyId,Passwords from Faculty";
            }
            else
            {
                sqlQuery = "Select StudentId,Passwords from Student";
            }
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sqlQuery;
            cmd.Connection = conn;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string _username = reader.GetString(0).Trim();
                string _password = reader.GetString(1).Trim();
                if (username.Equals(_username) && password.Equals(_password))
                {
                    if (id.Equals("0"))
                    {
                        Response.Redirect("Admin.aspx?Name=" + UserName.Text);
                        Session["User_ID"] = UserName.Text;
                    }
                    else if (id.Equals("1"))
                    {
                        Response.Redirect("Faculty.aspx?Name=" + UserName.Text);
                        Session["User_ID"] = UserName.Text;
                    }
                    else
                    {
                        Response.Redirect("Student Console.aspx?Name=" + UserName.Text);
                        Session["User_ID"] = UserName.Text;
                    }
                    break;
                }
                else
                {
                    Label.Visible = true;
                }
            }
            reader.Close();
            reader = null;
            cmd.Dispose();
            cmd = null;
            conn.Close();
        }
    }
}