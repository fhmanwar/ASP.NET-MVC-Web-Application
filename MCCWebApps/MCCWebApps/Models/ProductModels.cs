using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MCCWebApps.Models
{
    [Table("Tbl_Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string nm_product { get; set; }
        public int price { get; set; }
        public int stock { get; set; }
    }
}