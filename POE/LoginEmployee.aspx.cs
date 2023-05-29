using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POE
{
    public partial class Login : System.Web.UI.Page
    {
        DbControl DBCHere = new DbControl(); // creating object of DB control class
        Utilities util = new Utilities(); // creating object of Utilities class
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoggedIn_Click(object sender, EventArgs e)
        {
            String Username=txtUsername.Text; // assigning local variables values from page controls
            String Password=util.HashPassword(txtPassword.Text); // assigning local variables values from page controls,
                                                                 // and hashing the password so that it can be compared
                                                                 // to the hashed password stored in the database

            if ((Username.Equals("")) || (Password.Equals(""))) // checking that all fields have input
            {
                ErrorMessage.Text = "Please Enter both Username and Password";
            }
            else
            {                               
                if (DBCHere.AuthenticateEmployee(Username,Password)==true) // checking if the user exists in the database and that the credentials match
                {
                    Session["user"] = Username;
                    Response.Redirect("EmployeeHome.aspx");
                }
                else
                {
                    ErrorMessage.Text = "Username or password incorrect";
                }
            }
        }
    }
}