<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student Console.aspx.cs" Inherits="LMS.Student_Console" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Console</title>
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
            <h2 style="text-align:center; font-size:20px;font-family:lato;">Subject Wise Graph</h2> <br />
            <asp:Chart ID="Chart1" runat="server" OnLoad="Chart1_Load" Width="650px" Height="200px" BackColor="237, 237, 237" BackGradientStyle="TopBottom" BorderlineColor="Silver">
                <Series>
                    <asp:Series Name="Series1" YValuesPerPoint="2"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                        <AxisX Title="Course Code"></AxisX>
                        <AxisY Title="Course Marks"></AxisY>
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
        </div>
    </form>
</body>
</html>
