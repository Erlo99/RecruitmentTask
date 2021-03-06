using RecruitmentTask.Models.Foreign;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentTask.Models
{
    [Table("Order")]
    public class Order : Auditable
    {
        public Order(int id, PersonalData buyerData, PersonalData sellerData)
        {
            Id = id;
            BuyerData = buyerData;
            SellerData = sellerData;
        }

        [Key]
        public int Id { get; set; }
        public PersonalData BuyerData { get; set; }
        public PersonalData SellerData { get; set; }
    }
}
