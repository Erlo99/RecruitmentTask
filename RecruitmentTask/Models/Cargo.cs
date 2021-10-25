using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentTask.Models
{
    [Table("Cargo")] 
    public class Cargo
    {
        public Cargo(int id, int orderId, string name, int quantity, string barcode)
        {
            Id = id;
            OrderId = orderId;
            Name = name;
            Quantity = quantity;
            Barcode = barcode;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        public string Name { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string Barcode { get; set; }
    }
}
