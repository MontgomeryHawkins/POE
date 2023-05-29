using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using POE.Properties;

namespace POE
{
    public partial class FarmerHome : System.Web.UI.Page
    {
        Product producthere = new Product();
        DbControl DBCHere = new DbControl();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null) // Code to make sure the user is logged in to view data, and cant simply navigate to the page and view data
            {
                lblWelcome.ForeColor = System.Drawing.Color.Red;
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
            }

        }

        /// <summary>
        /// This method performs validation on the user input concerning product data, then 
        /// uses the db control class object to call the method that adds a product to the DB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            String ProductName;
            String ProductDescription;
            int Quantity;
            DateTime DateDelivered;
            try // try catch block to catch and conversion exceptions
            {
                if ((txtProductName.Text.Equals("")) || (txtDescription.Text.Equals("")) || (txtQuantity.Text.Equals(""))) // code that makes sure that all fields have values
                {
                    ErrorMessage.Text = "Please enter values for all fields";
                }
                else
                {
                    // Assigning local variables values from the controls on the page
                    ProductName = txtProductName.Text;
                    ProductDescription = txtDescription.Text;
                    Quantity = Convert.ToInt32(txtQuantity.Text);
                    DateDelivered = calDeliveryDate.SelectedDate.Date;
                    producthere = new Product(); // creating new product object
                    producthere.ProductName = ProductName; // adding values to the products attributes
                    producthere.Description = ProductDescription; // adding values to the products attributes
                    producthere.DateDelivered = DateDelivered; // adding values to the products attributes
                    producthere.Quantity = Quantity; // adding values to the products attributes
                    DBCHere.AddProduct(producthere, (string)Session["user"]); // calling DB control method to add the product to the DB
                    txtProductName.Text = ""; // resetting controls
                    txtDescription.Text = "";// resetting controls
                    txtQuantity.Text = "";// resetting controls
                }
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = "Please enter a number for quantity"; // error message display 
            }


            
        }

        /// <summary>
        /// Button that displays the products added by the currently logged in farmer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDisplay_Click(object sender, EventArgs e)
        {
            String Username = (string)Session["user"];
            DataSet dset = DBCHere.DisplayData(Username);
            productData.DataSource = dset;
            productData.DataBind();
        }
    }
}