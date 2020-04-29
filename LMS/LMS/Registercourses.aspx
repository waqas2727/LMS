<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registercourses.aspx.cs" Inherits="LMS.Courses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Courses</title>
    <link rel="stylesheet" href="StyleSheet.css" />
    <style>
        .student_info1 {
            margin-left:400px;
        }
    </style>
</head>
<body style="background-color:rgb( 237,237,237);">
    <form id="form1" runat="server">
        <h6 class="main">Student Console</h6><br />
        <div id="sidebar"> 
            <div class="list">
                <div class="item"><img src="gender_img.png" alt="student_pic" style="border-radius:50%"/></div>
                <div class="item"><asp:Button ID="Button1" runat="server" Text="Register Courses" BackColor="#404040" BorderStyle="None" style="color:white; font-size:16px" OnClick="Button1_Click"/></div>
                <div class="item"><asp:Button ID="Button2" runat="server" Text="Assement Marks" BackColor="#404040" BorderStyle="None" style="color:white; font-size:16px" OnClick="Button2_Click"/></div>
                <div class="item"><asp:Button ID="Button3" runat="server" Text="Change Password" BackColor="#404040" BorderStyle="None" style="color:white; font-size:16px" OnClick="Button3_Click"/></div>                
                <div class="item"><asp:Button ID="Button5" runat="server" Text="Log Out" BackColor="#404040" BorderStyle="None" style="color:white; font-size:16px" OnClick="Button5_Click"/></div>
            </div>
        </div>
        <div class="student_info">
            Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox> 
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            Registration Number&nbsp;&nbsp;&nbsp; 
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br /><br /><br />
            Semester&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            Register Courses&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;    
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br /> <br /><br /> <br />
            <h6 style="font-size:23px;">Registered Courses</h6>
        </div>
        
        <div class="student_info1">
            
            <asp:GridView ID="Student" runat="server" AutoGenerateColumns="false" Height="150px" Width="700px" >
                <Columns>
                    <asp:BoundField DataField="CourseName" HeaderText="Name"  ItemStyle-Width="150" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField DataField="CeditHours" HeaderText="Credit Hours" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField DataField="Instructor" HeaderText="Instructor Name" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField DataField="Section" HeaderText="Section" ItemStyle-HorizontalAlign="Center"/>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
