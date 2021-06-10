using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFInsuranceRegistrationAPI
{
    interface ICustomer
    {
        string FirstName { get; set; }
        string SurName { get; set; }
        string PolicyReferenceNumber { get; set; }
        DateTime DateOfBirth { get; set; }
        string PolicyHolderEmailAddress { get; set; }

    }
}
