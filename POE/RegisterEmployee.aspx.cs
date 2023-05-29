using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POE
{
    public partial class RegisteEmployee : System.Web.UI.Page
    {
        DbControl DBCHere = new DbControl();
        Employee EmployeeHere = new Employee(); // creating an empty employee object
        Utilities util = new Utilities();
        // ^^ Creating objects of classes that provide valuable methods
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
                    else if (txtPassword.Text.Length<8)
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
                    Username = txtUsername.Text; // assigning values to the local variables from form controls
                    Fullname = txtFullname.Text; // assigning values to the local variables from form controls
                    EmailAddress = txtEmail.Text; // assigning values to the local variables from form controls
                    Password = util.HashPassword(txtPassword.Text); //Hashing password before creating employee object


                    EmployeeHere.EmployeeUsername = Username; // assigning local employee object values
                    EmployeeHere.Fullname = Fullname; // assigning local employee object values
                    EmployeeHere.EmailAddress = EmailAddress; // assigning local employee object values 
                    EmployeeHere.Password = Password; // assigning local employee object values
                    DBCHere = new DbControl();
                    
                    DBCHere.RegisterEmployee(EmployeeHere); // calling method in the DB control class to register the employee
                    
                    Response.Redirect("LoginEmployee.aspx"); // redirecting the login page
                    
                }
                

            }
            catch 
            {
                ErrorMessage.Text = "An Error Occurred";
            }
            
            
            
        }
    }
}