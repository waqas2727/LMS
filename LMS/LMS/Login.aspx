<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LMS.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <style>
        .banner {
            width: 100%;
            max-width: 520px;
            margin: 70px 90px 10px 400px;
            text-align:center;
        }
        img{
            max-width:100%;
        }
        .mainselection{
            background: #DEDEDE;
            border-color: #DEDEDE;
            margin: 60px 500px auto 635px ;
        }
        .main {
            background-image:url(/rizwan.jpeg)
        }
        h6 {
            font: algerian;
            text-align :center ;
            font-size : 15px;
        }
    </style>
</head>
<body class="main">
    <div class="banner">
        <div>
            <img alt="Logo" class="auto-style1" src="logo_black1.png" />
        </div>
    </div>
    <form id="form1" runat="server">
        <div class="banner"> 
            UserName&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="UserName" runat="server"></asp:TextBox> 
            <br />
            <br />
            Password&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            Designation&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList1" runat="server" Height="30px" Width="143px" style="font-style: oblique" BackColor="#DEDEDE" Font-Names="Algerian">
                <asp:ListItem Value="0">Admin</asp:ListItem>
                <asp:ListItem Value="1">Faculty</asp:ListItem>
                <asp:ListItem Value="2">Student</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label" runat="server" Text="Invalid UserID or Password" Font-Size="Smaller" Font-Italic="True" BorderColor="Red" ForeColor="Red"></asp:Label>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" BackColor="#4169E2" />
        </div>
    </form>
</body>
</html>
