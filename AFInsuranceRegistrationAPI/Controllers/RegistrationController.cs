using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AFInsuranceRegistrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {

        int CustomerID = 0;
        [HttpPost]
        public int CaptureCustomerInfo(Models.CustomerModel customer)
        {
            // Validating data coming through the API post request
            if (ModelState.IsValid)
            {
                DateTime dob = customer.DateOfBirth;

                DateTime CurrentDate = DateTime.Now;
                //Checking current age of the Customer
                int CurrentAge = CurrentDate.Year - dob.Year;

                // Check if policy holder is above 18 while registration
                if (CurrentAge >= 18)
                {
                    //Create customer record
                    CustomerID = SaveCustomer(customer);
                }

            }

            return CustomerID;
        }

        public int SaveCustomer(Models.CustomerModel customerdata)
        {

            string fileName = @"C:\Users\sc32762\CustomerDetails.txt";

            // If File does not exits create file and save registration details with unique customer ID
            if (!System.IO.File.Exists(fileName))
            {

                using (StreamWriter writer = System.IO.File.CreateText(fileName))
                {
                    writer.WriteLine(++CustomerID + " " + customerdata.FirstName + " " + customerdata.SurName + " " + customerdata.PolicyReferenceNumber + " " + customerdata.DateOfBirth + " " + customerdata.PolicyHolderEmailAddress);
                }

            }
            //If File exits increment customer ID and save registration details with unique customer ID
            else
            {
                using (var reader = new StreamReader(fileName))
                {
                    while (reader.ReadLine() != null)
                    {
                        CustomerID++;
                    }
                    reader.Close();
                    using (StreamWriter writer = System.IO.File.AppendText(fileName))
                    {
                        writer.WriteLine(++CustomerID + " " + customerdata.FirstName + " " + customerdata.SurName + " " + customerdata.DateOfBirth + " " + customerdata.PolicyHolderEmailAddress + " " + customerdata.PolicyReferenceNumber);
                    }
                }
            }

            return CustomerID;
        }


    }
}
