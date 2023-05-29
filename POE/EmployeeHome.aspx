<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/EmpLoggedIn.Master" CodeBehind="EmployeeHome.aspx.cs" Inherits="POE.EmployeeHome" %>

<asp:Content id="Content1" ContentPlaceHolderID="MainContent1" runat="server">
    <!DOCTYPE html>
<html>
<head>
<style>
.container {
  position: relative;
}

.topPanel {
  font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
  width: 300px;
  text-align: center;
  font-size: 18px;
  margin:10px auto ;
  border-radius:25px;
  flex-direction:column;
  display: flex;
  border:2px solid;
}

.centerPanel {
  font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
  width: 100%;
  opacity:100%;
  text-align: center;
  font-size: 18px;
  margin:50px auto ;
  flex-direction:column;
  display: flex;
  border-radius:20px;
  border:2px solid;
}

.innerpanel
{
    margin: 10px auto;
    border-radius:20px;
    height: 70px;
    border:2px solid;
    opacity:100%;
}
.pstyle
{
    margin-top:10px;
    font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
}
.welcomelabelstyle
{
    font-size:20px;
    font-family:Calibri;
    font-weight:bold;
    margin:auto;
}

.messagelabelstyle
{
    font-size:16px;
    font-family:Calibri;
    margin:10px auto;
}
.buttondivstyle
{
    width:100%;
    display:flex;
    flex-direction:column;
    justify-content:center;
}

.divstyle
{
  margin: 10px auto;
  font-family: Calibri;
  text-align: center;
  font-size: 18px;
  flex-direction:column;
  display: flex;
  border-radius:20px;
  height:fit-content;
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
    font-size: 16px;
    margin:20px auto 5px auto;
    width: 100px;
    border-radius: 10px;
    height: 30px;
    opacity:100%;
    width:300px;
    height:50px;
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
    <asp:Panel ID="Panel1" CssClass="topPanel" runat="server" BorderColor="#000000"  
    Height="40px"  BackColor="White" >
        <asp:Label ID="lblWelcome" runat="server" Text="" CssClass="welcomelabelstyle"></asp:Label>
        
        
   </asp:Panel>
    <asp:Panel ID="Panel2" CssClass="centerPanel" runat="server" BorderColor="#000000"  
     Height="300px" Width="800px" BackColor="White">
        
        <div class="divstyle">
            <asp:Panel ID="Panel3" CssClass="innerpanel" runat="server" BorderColor="#000000"  
              Width="700px" BackColor="White" >
                <label id="messagelabel" class="messagelabelstyle">This is the employee home page. From here you can add a farmer to the system,
                or interact with the products already stored in the system
                </label>

            </asp:Panel>         
       </div>
        <div class="buttondivstyle">
            <asp:Button ID="btnAddFarmer" CssClass="ButtonStyle" runat="server" Text="Add a Farmer" OnClick="btnAddFarmer_Click" />
            <asp:Button ID="btnProducts"  CssClass="ButtonStyle" runat="server" Text="Go to products" OnClick="btnProducts_Click" />

        </div>

    </asp:Panel>
  
</div>
</body>
</html>
</asp:Content>
