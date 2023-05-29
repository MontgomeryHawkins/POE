using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace POE
{
    public class Utilities
    {

        public String HashPassword(String Password)
        {
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider(); //creating new crypto service provider
            byte[] passwordbytearray = Encoding.ASCII.GetBytes(Password); // creating array of bytes from password
            byte[] encryptedbasswordbytes = sha1.ComputeHash(passwordbytearray); // creating a hashed byte array
            return Convert.ToBase64String(encryptedbasswordbytes); // returning the hashed string
        }


    }

    
}