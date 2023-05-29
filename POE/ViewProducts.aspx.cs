using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POE
{
    
    public partial class ViewProducts : System.Web.UI.Page
    {
        private int selectedFarmerIndex;
        private int selectedProductIndex;
        private DbControl DBCHere = new DbControl(); // creating an object of the dbcontrol class
        private String FarmerName;
        private String ProductName;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"]==null) // Code to make sure the user is logged in to view data, and cant simply navigate to the page and view data
            {
                lblWelcome.ForeColor= System.Drawing.Color.Red;
                lblWelcome.Text = "Please Log In";
            }
            else if (Session["user"].Equals(""))
            {
                lblWelcome.ForeColor = System.Drawing.Color.Red;
                lblWelcome.Text = "Please Log In";
            }
            else
            {
                lblWelcome.Text = "Welcome, " + (string)Session["user"];

                GetIndex(); 
                //following code is used to populate the dropdownlists
                listFarmers.SelectedIndex = selectedFarmerIndex;
                listProducts.SelectedIndex = selectedProductIndex;
                PopulateFarmerList();
                PopulateProductList();
            }
            
        }

        /// <summary>
        /// method that receives user input data and calls the method from the DB control class to display the 
        /// product data on a table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDisplayProducts_Click(object sender, EventArgs e)
        {
            this.FarmerName = listFarmers.SelectedValue;
            DataSet dset = DBCHere.DisplayData(FarmerName);
            if (dset.Tables[0].Rows.Count==0)
            {
                ErrorMessage.Text = "This farmer has no products listed";
            }
            else
            {
                productData.DataSource = dset;
                productData.DataBind();
            }
            
        }

        private void GetIndex()
        {
            selectedFarmerIndex = listFarmers.SelectedIndex;
            selectedProductIndex = listProducts.SelectedIndex;
        }

        /// <summary>
        /// method that uses the method in the DB control class to get the list of farmer names and populate
        /// the dropdownlist with the names
        /// </summary>
        private void PopulateFarmerList()
        {
            DataTable dt = new DataTable();
            dt = DBCHere.FarmerNameList();
            DataTable dt2 = new DataTable();
            if (dt.Rows.Count > 0)
            {
                listFarmers.DataSource = dt;
                listFarmers.DataValueField = "FarmerUsername";
                listFarmers.DataTextField = "FarmerUsername";
                listFarmers.DataBind();
            }
            else
            {

            }
        }

        /// <summary>
        /// method that uses the method in the DB control class to get the list of products and populate
        /// the dropdownlist with the names
        /// </summary>
        private void PopulateProductList()
        {
            DataTable dt = new DataTable();
            dt = DBCHere.ProductList();
            DataTable dt2 = new DataTable();
            if (dt.Rows.Count > 0)
            {
                listProducts.DataSource = dt;
                listProducts.DataValueField = "ProductName";
                listProducts.DataTextField = "ProductName";
                listProducts.DataBind();
            }
            else
            {

            }
        }

        /// <summary>
        /// method that receives user input and sends the input to the db control class method to filter the product data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnFilterType_Click(object sender, EventArgs e)
        {
            this.FarmerName = listFarmers.SelectedValue;
            this.ProductName = listProducts.SelectedValue;
            DataSet dset = DBCHere.FilterType(ProductName,FarmerName);
            productData.DataSource = dset;
            productData.DataBind();
        }

        /// <summary>
        /// method that receives user input and sends the input to the db control class method to filter the product data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnFilterDate_Click(object sender, EventArgs e)
        {
            this.FarmerName = listFarmers.SelectedValue;
            DateTime Date1 = calDate1.SelectedDate;
            DateTime Date2 = calDate2.SelectedDate;
            DataSet dset = DBCHere.FilterDate(FarmerName, Date1, Date2);
            productData.DataSource = dset;
            productData.DataBind();
        }
    }
}