using RecruitmentTask.Models.Foreign;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentTask.Models.Dto
{
    public class OrderDto
    {
        public PersonalData BuyerData { get; set; }
        public PersonalData SellerData { get; set; }
        [Required]
        public List<Cargo> cargos { get; set; }
    }
}
