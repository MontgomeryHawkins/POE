using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POE
{
    public partial class EmployeeHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Welcome, " + (string)Session["user"];
        }

        protected void btnAddFarmer_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterFarmer.aspx");
        }

        protected void btnProducts_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewProducts.aspx");
        }
    }
}