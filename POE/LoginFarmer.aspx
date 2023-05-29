<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="LoginFarmer.aspx.cs" Inherits="POE.LoginFarmer" %>

<asp:Content id="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!DOCTYPE html>
<html>
<head>
<style>
.container {
  position: relative;
}

.centerPanel {
  font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
  width: 100%;
  text-align: center;
  font-size: 18px;
  margin:100px auto ;
  border-radius:25px;
  flex-direction:column;
  display: flex;
}
.pstyle
{
    margin-top:10px;
    font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
}
.labelstyle
{
    font-size:14px;
    
    padding:10px;
}
.divstyle
{
    font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
  width: 100%;
  text-align: center;
  font-size: 18px;
  justify-content:center;
  flex-direction:column;
  display: flex;
}
.txtboxstyle
{
     font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
    font-size: 14px;
    width: 110px;
}
.ButtonStyle
{
    font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
    font-size: 14px;
    margin:20px auto 5px auto;
    width: 100px;
    border-radius: 10px;
    height: 30px;
}
.ErrorStyle
{
    font-size: 14px;
    
    color:red;
}

</style>
</head>
<body>
    


<div class="container">
    <asp:Panel ID="Panel1" CssClass="centerPanel" runat="server" BorderColor="#000000"  
    Height="300px" Width="250px" BackColor="White">
        <p class="pstyle">Farmer Login</p>
        <div>
            <label class="labelstyle">Username:</label>
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            <label class="labelstyle">Password:</label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            <div class="divstyle">
                <asp:Button ID="btnSubmit" class="ButtonStyle" runat="server" text="Submit" OnClick="btnSubmit_Click"/>
            <asp:Label ID="ErrorMessage" runat="server" CssClass="ErrorStyle" Text=""></asp:Label>
            </div>
            
            
        </div>
        

   </asp:Panel>
  
</div>

</body>
</html>
                    
                
    

    
   
   

    
    
</asp:Content>   
