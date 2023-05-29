<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/EmpLoggedIn.Master" CodeBehind="ViewProducts.aspx.cs" Inherits="POE.ViewProducts" %>

<asp:Content id="Content1" ContentPlaceHolderID="MainContent1" runat="server">
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
    font-size: 16px;
    font-weight:bold;
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
    font-weight:normal;
}
.contentdivstyle
{
    height:500px;
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
    height:fit-content;
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
    margin:10px auto auto auto;
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
    width:400px;
    display:flex;
    flex-direction:column;
}
.inputdiv
{
    justify-content:center;
    margin:auto;
    display:flex;
    flex-direction:row;
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
.calendar
{
    height:20px;
    width:110px;
    font-size:10px;
    border-radius:15px;
    padding:5px;
}
.calendardiv
{
    justify-content:center;
    margin:10px;
    display:flex;
    flex-direction:column;
    
}
.gridpanel
{
    margin:auto;
    width:100%;
    height:100%;
    border-radius:15px;
    border:2px solid;
    justify-content:center;
    overflow:scroll;
}
.gridstyle
{
    margin:20px 20px 20px 20px;
    width:90%;
    

}
.dropdownstyle
{
    font-family:Calibri;
    font-size:14px;
    width:150px;
    height:20px;
    margin:auto;
}
.dropdownstyle2
{
    font-family:Calibri;
    font-size:14px;
    width:100px;
    height:20px;
    margin:auto;
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
    Height="40px" Width="320px" BackColor="White" >
        <asp:Label ID="lblWelcome" runat="server" Text="" CssClass="welcomelabelstyle"></asp:Label>
        
        
   </asp:Panel>
    <asp:Panel ID="Panel2" CssClass="centerPanel" runat="server" BorderColor="#000000"  
     Height="615px" Width="1100px" BackColor="White">
        
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
                    <p class="pstyle">View Products</p>
                <div class="inputdiv">
                    <label class="messagelabelstyle">Farmer Name:</label>
                    <asp:DropDownList runat="server" ID="listFarmers" CssClass="dropdownstyle"></asp:DropDownList> 
                </div>
                <div class="inputdiv">
                    <asp:Button runat="server" ID="btnDisplayProducts" CssClass="ButtonStyle" Text="Display Products" OnClick="btnDisplayProducts_Click"  />
                </div>
                <div class="inputdiv">
                    <hr />
                    <asp:DropDownList runat="server" ID="listProducts" CssClass="dropdownstyle2"></asp:DropDownList>
                    <asp:Button runat="server" ID="btnFilterType" CssClass="ButtonStyle" Text="Filter Product Type" OnClick="btnFilterType_Click" />
                </div>
                <div class="inputdiv">
                    <div class="calendardiv">
                        <label class="messagelabelstyle">Date 1:</label>
                        <asp:Calendar runat="server" ID="calDate1" CssClass="calendar"></asp:Calendar>
                    </div>
                    <div class="calendardiv">
                        <label class="messagelabelstyle">Date 2:</label>
                        <asp:Calendar runat="server" ID="calDate2" CssClass="calendar"></asp:Calendar>
                    </div>
                </div>
                <div class="inputdiv">
                    <asp:Button runat="server" ID="btnFilterDate" CssClass="ButtonStyle" Text="Filter by Date Delivered" OnClick="btnFilterDate_Click" />
                </div>
                <div class="inputdiv">
                    <asp:Label ID="ErrorMessage" runat="server" CssClass="ErrorStyle" Text=""></asp:Label>
                </div>
                </asp:Panel>
                

            </div>
            <div id="div" class="griddivstyle">
                <asp:Panel runat="server" ID="gridpanel" CssClass="gridpanel">
                    <gridview></gridview>
                    <asp:DataGrid runat="server" ID="productData" CssClass="gridstyle" ></asp:DataGrid>
                </asp:Panel>
                
                
            </div>

        </div>

    </asp:Panel>
  
</div>
</body>
</html>
</asp:Content>
