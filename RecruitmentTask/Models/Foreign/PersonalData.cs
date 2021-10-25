using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentTask.Models.Foreign
{
    public class PersonalData
    {
        [Required]
        public string FristName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        public string AdditionalAddress { get; set; }
        [Required]
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public string ZipCode { get; set; }
    }
}
