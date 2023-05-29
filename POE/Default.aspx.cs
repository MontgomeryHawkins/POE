using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POE
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["user"] = ""; //resets the logged in user's username after they log out
        }

        protected void btnLoginEmp_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginEmployee.aspx");
        }

        protected void btnLoginFarmer_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginFarmer.aspx");
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterEmployee.aspx");
        }
    }
}