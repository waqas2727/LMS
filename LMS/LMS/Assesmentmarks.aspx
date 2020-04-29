<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Assesmentmarks.aspx.cs" Inherits="LMS.Assesmentmarks" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Assesment Marks</title>
    <link rel="stylesheet" href="StyleSheet.css" />
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
        </div>
        <br /> <br /><br /> <br />
        <div class="student_info">
            <asp:DropDownList ID="Subjects" runat="server" Height="16px" Width="250px"></asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button6" runat="server" Text="See Result" OnClick="Button6_Click"/>
        </div>
    </form>
</body>
</html>
