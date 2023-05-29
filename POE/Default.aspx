<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="POE._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!DOCTYPE html>
<html>
<head>
<style>
.container 
{
  position: relative;
}
.centerPanel {
    width: 100%;
    text-align: center;
    margin:100px auto ;
    border-radius:25px;
    flex-direction:column;
    display: flex;
}
.pstyle
{
    font-size:20px;
    font-family:Calibri;
    padding:10px;
    font-weight:bold;
}
.pstyle2
{
    font-size:16px;
    font-family:Calibri;
    font-weight:normal;
}
.ButtonStyle
{
    font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
    font-size: 16px;
    margin:20px auto 5px auto;
    width: 100px;
    border-radius: 10px;
    height: 30px;
    opacity:100%;
    width:300px;
    height:50px;
}
</style>
</head>
<body>
<asp:Panel ID="Panel1" CssClass="centerPanel" runat="server" BorderColor="#000000"  
    Height="330px" Width="300px" BackColor="White">
    <p class="pstyle">Welcome to Farm Central</p>
    <p class="pstyle2">Choose one of the following actions:</p>
    <asp:Button ID="btnLoginEmp" CssClass="ButtonStyle" runat="server" Text="Login as an Employee" OnClick="btnLoginEmp_Click" />
    <asp:Button ID="btnLoginFarmer" CssClass="ButtonStyle" runat="server" Text="Login as a farmer" OnClick="btnLoginFarmer_Click" />
    <asp:Button ID="btnRegister" CssClass="ButtonStyle" runat="server" Text="Register as an employee" OnClick="btnRegister_Click" />
</asp:Panel>


</body>
</html>

    
</asp:Content>
