using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POE
{
    public partial class RegisterFarmer : System.Web.UI.Page
    {
        DbControl DBCHere = new DbControl();
        Farmer FarmerHere = new Farmer();// creating an empty farmer object
        Utilities util = new Utilities();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            String Username;
            String Fullname;
            String EmailAddress;
            String Password;
            //^^ creating local variables to store user input
            try //try catch block to catch any exception
            {
                if ((txtUsername.Text.Equals("")) || (txtFullname.Text.Equals("")) || (txtEmail.Text.Equals("")) || (txtPassword.Text.Equals(""))) // checking that all fields have input
                {
                    //ˇˇ nested if that checks that ll of the input is valid according to the business logic
                    if ((!txtEmail.Text.Contains("@")) || (!txtEmail.Text.Contains(".com")))
                    {
                        ErrorMessage.Text = "Please enter a valid email address";
                    }
                    else if (txtPassword.Text.Length < 8)
                    {
                        ErrorMessage.Text = "Password must be 8 or more characters";
                    }
                    else
                    {
                        ErrorMessage.Text = "Please enter data in all fields";
                    }
                }
                else
                {
                    Username = txtUsername.Text;// assigning values to the local variables from form controls
                    Fullname = txtFullname.Text;// assigning values to the local variables from form controls
                    EmailAddress = txtEmail.Text;// assigning values to the local variables from form controls
                    Password = util.HashPassword(txtPassword.Text); //Hashing password before creating employee object


                    FarmerHere.FarmerUsername = Username; // assigning local employee object values
                    FarmerHere.Fullname = Fullname; // assigning local employee object values
                    FarmerHere.EmailAddress = EmailAddress; // assigning local employee object values 
                    FarmerHere.Password = Password;// assigning local employee object values
                    DBCHere = new DbControl();
                    
                    DBCHere.RegisterFarmer(FarmerHere); // calling method in the DB control class to register the farmer
                    ErrorMessage.CssClass = "SuccessStyle";
                    ErrorMessage.Text = "Sucessfully Added Farmer"; // displaying a success message for the user
                    txtEmail.Text = ""; // resetting contol text
                    txtFullname.Text = ""; // resetting control text
                    txtPassword.Text = ""; // resetting control text
                    txtUsername.Text = ""; // resetting control text

                }


            }
            catch
            {
                ErrorMessage.Text = "An Error Occurred";
            }
        }
    }
}