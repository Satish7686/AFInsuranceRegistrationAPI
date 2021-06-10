using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AFInsuranceRegistrationAPI.Models
{
    public class CustomerModel : ICustomer
    {

      // First Name Validation minimun 3 charectors max 50 charectors
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string FirstName { get; set; }

        // SurName Validation minimun 3 charectors max 50 charectors
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string SurName { get; set; }

        // Policy Reference validation accepting two capitalised alpha character followed by a hyphen and 6 numbers
        [Required]
        [RegularExpression(@"^[A-Z]{2}[-]\d{6} *$")]
        public string PolicyReferenceNumber { get; set; }
        
       
        public DateTime DateOfBirth { get; set; }

        // Email validation accepting a string of at least 4 alpha numeric chars followed by an ‘@’ sign and then another string of at least 2 alpha numeric chars.The email address should end in either ‘.com’ or ‘.co.uk’
        [RegularExpression(@"^[a-zA-Z0-9_.+-]{4,99}@[a-zA-Z0-9-]{2,99}\.[\.com or co\.uk]+$")]
        public string PolicyHolderEmailAddress { get; set; }

    }
}
