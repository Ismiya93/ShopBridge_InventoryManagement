using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge_InventoryManagement.Models
{
    public class Products
    {
        [Key]
        public long ID { get; set; }

        [StringLength(100), Required]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
