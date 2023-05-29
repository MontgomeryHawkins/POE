using POE.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime;
using System.Web;

namespace POE
{
    /// <summary>
    /// This class contains all of the interaction with the database. All classes that interact with the DB
    /// use this class's methods
    /// </summary>
    public class DbControl
    {
        private readonly String connectionString = Settings.Default.ConnectionString; //setting connectionstring value to global connectionstring setting
        private FarmerDBEntities Entity; // Creating entity framework instance

        
        public bool AuthenticateEmployee(String UsernameIN,String PasswordIN) //method used to accept user input and log them in using the database
        {
            try //try catch block to catch exceptions
            {
            using (this.Entity = new FarmerDBEntities()) //using the created entity to check the employees for the employeedetails
            {
                var Employee = this.Entity.Employees.Find(UsernameIN);

                if (Employee != null)
                    {
                        if (Employee.Password == PasswordIN)
                        {
                            return true; // returning true if the user is found
                        }
                        else 
                        {
                            return false; // or returning false if the user is not found
                        }
                    }                                
            }
            }
            catch (Exception e)
            {

                return false;
            }

            return false;
        }

        public bool AuthenticateFarmer(String UsernameIN, String PasswordIN) //method used to accept user input and log them in using the database
        {
            try //try catch block to catch exceptions
            {
                using (this.Entity = new FarmerDBEntities()) //using the created entity to check the employees for the employeedetails
                {
                    var Farmer = this.Entity.Farmers.Find(UsernameIN);

                    if (Farmer != null)
                    {
                        if (Farmer.Password == PasswordIN)
                        {
                            return true; // returning true if the user is found
                        }
                        else
                        {
                            return false; // or returning false if the user is not found
                        }
                    }
                }
            }
            catch (Exception e)
            {

                return false;
            }

            return false;
        }



        public void RegisterEmployee(Employee EmployeeDetails) // method that receives an employee object and adds the user to the DB
        {            
            Entity = new FarmerDBEntities(); // creating an instance of the entity framework
            Entity.Employees.Add(EmployeeDetails); // Adding the employee to the employee list
            Entity.SaveChanges(); // committing the changes to the entity
        }
        public void RegisterFarmer(Farmer FarmerDetails) // method that receives an employee object and adds the user to the DB
        {
            Entity = new FarmerDBEntities();// creating an instance of the entity framework
            Entity.Farmers.Add(FarmerDetails);// Adding the farmer to the employee list
            Entity.SaveChanges();// committing the changes to the entity
        }

        /// <summary>
        /// Method that receives product information and a farmer name and adds the product to the DB
        /// </summary>
        /// <param name="ProductIn"></param>
        /// <param name="FarmerUsernameIN"></param>
        public void AddProduct(Product ProductIn,String FarmerUsernameIN)
        {
            FarmerProduct FP = new FarmerProduct();
            FP.FarmerUsername = FarmerUsernameIN;
            FP.ProductID = ProductIn.ProductID; 
            Entity = new FarmerDBEntities();
            Entity.Products.Add(ProductIn);
            Entity.FarmerProducts.Add(FP);
            Entity.SaveChanges();
        }

        /// <summary>
        /// Method that accepts farmer username and queries the DB to return all of the products added by that farmer as a DataSet
        /// </summary>
        /// <param name="FarmerUsernameIN"></param>
        /// <returns></returns>
        public DataSet DisplayData(String FarmerUsernameIN)
        {
            String Query = "SELECT P.ProductName,P.Description,P.Quantity,P.DateDelivered FROM Product P LEFT JOIN FarmerProduct FP ON P.ProductID=FP.ProductID WHERE FP.FarmerUsername=@FarmerUsername;";
            String FarmerName = FarmerUsernameIN;
            SqlDataAdapter dAdapter;
            DataSet dset;
            using (SqlConnection connection = new SqlConnection(connectionString)) // creating temporary connection to the DB
            {
                SqlCommand cmd = new SqlCommand(Query, connection);
                cmd.Parameters.AddWithValue("@FarmerUsername", FarmerName);
                dAdapter = new SqlDataAdapter(cmd);
                dset = new System.Data.DataSet();
                dAdapter.Fill(dset);
                return dset;                             
            }           
        }

        /// <summary>
        /// Method that returns all of the farmer usernames from the farmer table in the DB
        /// </summary>
        /// <returns></returns>
        public DataTable FarmerNameList()
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataTable dt1 = new DataTable();
                string q = "SELECT FarmerUsername FROM Farmer";
                SqlCommand cmd = new SqlCommand(q, connection);
                try
                {
                    SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                    da2.Fill(dt1);
                }
                catch { }
                return dt1;
            }
        }

        /// <summary>
        /// Method that returns all of the product names from the product table in the DB
        /// </summary>
        /// <returns></returns>
        public DataTable ProductList()
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataTable dt1 = new DataTable();
                string q = "SELECT DISTINCT ProductName FROM Product";
                SqlCommand cmd = new SqlCommand(q, connection);
                try
                {
                    SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                    da2.Fill(dt1);
                }
                catch { }
                return dt1;
            }
        }

        /// <summary>
        /// method that accepts a product name and farmer user name and searches the db for products 
        /// that have the same name added by the specified farmer using link table queries
        /// the method then returns a dataset of the products that were found
        /// </summary>
        /// <param name="ProductIN"></param>
        /// <param name="FarmerUserIN"></param>
        /// <returns></returns>
        public DataSet FilterType(String ProductIN,String FarmerUserIN)
        {
            String Query = "SELECT P.ProductName,P.Description,P.Quantity,P.DateDelivered FROM Product P LEFT JOIN FarmerProduct FP ON P.ProductID=FP.ProductID WHERE FP.FarmerUsername=@FarmerUsername AND P.ProductName=@ProductName;";
            String FarmerName = FarmerUserIN;
            String ProductName = ProductIN;
            SqlDataAdapter dAdapter;
            DataSet dset;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(Query, connection);
                cmd.Parameters.AddWithValue("@ProductName", ProductName);
                cmd.Parameters.AddWithValue("@FarmerUsername",FarmerName);
                dAdapter = new SqlDataAdapter(cmd);
                dset = new System.Data.DataSet();
                dAdapter.Fill(dset);
                return dset;
            }
        }

        /// <summary>
        /// method that accepts the farmer username and two dates, then searches the database using link table
        /// queries to find products added by the specified farmer between the two dates,then the method
        /// returns the products as a dataset
        /// </summary>
        /// <param name="FarmerNameIN"></param>
        /// <param name="Date1"></param>
        /// <param name="Date2"></param>
        /// <returns></returns>
        public DataSet FilterDate(String FarmerNameIN,DateTime Date1, DateTime Date2)
        {
            String Query = "SELECT P.ProductName,P.Description,P.Quantity,P.DateDelivered FROM Product P LEFT JOIN FarmerProduct FP ON P.ProductID=FP.ProductID WHERE FP.FarmerUsername=@FarmerUsername AND P.DateDelivered>=@Date1 AND P.DateDelivered<=@Date2";
            DateTime Date1Here = Date1;
            DateTime Date2Here = Date2;
            String FarmerName = FarmerNameIN;
            SqlDataAdapter dAdapter;
            DataSet dset;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(Query, connection);
                cmd.Parameters.AddWithValue("@Date1", Date1);
                cmd.Parameters.AddWithValue("@Date2", Date2);
                cmd.Parameters.AddWithValue("@FarmerUsername", FarmerName);
                dAdapter = new SqlDataAdapter(cmd);
                dset = new System.Data.DataSet();
                dAdapter.Fill(dset);
                return dset;
            }
        }



    }
}