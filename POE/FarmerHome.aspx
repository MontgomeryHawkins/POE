<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/FarmerLoggedIn.Master" CodeBehind="FarmerHome.aspx.cs" Inherits="POE.FarmerHome" %>

<asp:Content id="Content1" ContentPlaceHolderID="MainContent2" runat="server">
    <!DOCTYPE html>
<html>
<head>
<style>
.container {
    position: relative;
}

.topPanel {
    font-family: Calibri;
    width: 100%;
    text-align: center;
    font-size: 18px;
    margin:10px auto ;
    border-radius:25px;
    flex-direction:column;
    display: flex;
    border:2px solid;
}

.centerPanel {
    font-family: Calibri;
    width: 100%;
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
    height: 50px;
    border:2px solid;
}
.pstyle
{
    margin-top:10px;
    font-family: Calibri;
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
.contentdivstyle
{
    height:550px;
    width:100%;
    display:flex;
    flex-direction:row;
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
    
}


.txtboxstyle
{
    margin:auto auto auto 15px;
    height:20px;
    font-family: Calibri;
    font-size: 14px;
    width: 110px;
}

.ButtonStyle
{
    font-family: Calibri;
    font-size: 14px;
    margin: auto;
    width: fit-content;
    border-radius: 5px;
    height: 30px;
}
.ErrorStyle
{
    font-size: 14px;
    color:red;
}
.detailsdiv
{
    width:500px;
    display:flex;
    flex-direction:column;
}
.inputdiv
{
    justify-content:left;
    margin:10px auto;
    display:flex;
    flex-direction:row;
}
.calendardiv
{
    justify-content:left;
    margin:10px 10px auto 10px;
    display:flex;
    flex-direction:column;
}
.detailspanel
{
    margin:auto auto auto 10px;
    width:100%;
    height:100%;
    border-radius:15px;
    border:2px solid;
    justify-content:center;
}
.griddivstyle
{
    margin:auto 20px auto 40px;
    height:500px;
    width:100%;
    
}
.gridpanel
{
    margin:auto;
    width:100%;
    height:90%;
    border-radius:15px;
    border:2px solid;
    justify-content:center;
    overflow:scroll;
}
.gridstyle
{
    margin:20px 20px 20px 20px;
    width:90%;
    
    height:90%;
}
.calendar
{
    height:80%;
    border-radius:15px;
}
</style>
</head>
<body>
<div class="container">
    <asp:Panel ID="Panel1" CssClass="topPanel" runat="server" BorderColor="#000000"  
    Height="40px" Width="320px" BackColor="White" >
        <asp:Label ID="lblWelcome" runat="server" Text="" CssClass="welcomelabelstyle"></asp:Label>
        
        
   </asp:Panel>
    <asp:Panel ID="Panel2" CssClass="centerPanel" runat="server" BorderColor="#000000"  
     Height="650px" Width="1100px" BackColor="White">
        
        <div class="divstyle">
            <asp:Panel ID="Panel3" CssClass="innerpanel" runat="server" BorderColor="#000000"  
              Width="700px" BackColor="White" >
                <label id="messagelabel" class="messagelabelstyle">This is the farmer home page, from here you can add a product and view the products you have added
                </label>

            </asp:Panel>         
       </div>
        <div class="contentdivstyle" id="Contentdiv">
            <div class="detailsdiv">
                <asp:Panel runat="server" ID="detailspanel" CssClass="detailspanel">
                    <p class="pstyle">Add a Product</p>
                <div class="inputdiv">
                    <label class="messagelabelstyle">Product Name:</label>
                    <asp:TextBox CssClass="txtboxstyle" runat="server" ID="txtProductName"></asp:TextBox>
                </div>
                <div class="inputdiv">
                    <label class="messagelabelstyle">Product Description:</label>
                    <asp:TextBox CssClass="txtboxstyle" runat="server" ID="txtDescription"></asp:TextBox>
                </div>
                <div class="inputdiv">
                    <label class="messagelabelstyle">Product Quantity:</label>
                    <asp:TextBox CssClass="txtboxstyle" runat="server" ID="txtQuantity"></asp:TextBox>
                </div>
                <div class="calendardiv">
                    <label class="messagelabelstyle">Delivery Date:</label>
                    <asp:Calendar runat="server" ID="calDeliveryDate" CssClass="calendar"></asp:Calendar>
                </div>
                <div class="inputdiv">
                    <asp:Button runat="server" CssClass="ButtonStyle" ID="btnSubmit" Text="Submit" OnClick="btnSubmit_Click" />
                    <asp:Button runat="server" CssClass="ButtonStyle" ID="btnDisplay" Text="Display your products" OnClick="btnDisplay_Click" />
                </div>
                    <asp:Label ID="ErrorMessage" runat="server" CssClass="ErrorStyle" Text=""></asp:Label>
                </asp:Panel>
                

            </div>
            <div id="div" class="griddivstyle">
                <asp:Panel runat="server" ID="gridpanel" CssClass="gridpanel">
                    <asp:GridView runat="server" ID="productData" CssClass="gridstyle"></asp:GridView>
                </asp:Panel>
                
                
            </div>

        </div>

    </asp:Panel>
  
</div>
</body>
</html>
</asp:Content>
