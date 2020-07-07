using Antlr.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MCCWebApps.Models
{
    [Table("Tbl_Transaction")]
    public class Transaction
    {
        [Key]
        public int Nota { get; set; }
        public int qty { get; set; }
        public int total { get; set; }
        public DateTimeOffset created_at { get; set; }

        public int id_product { get; set; }
        public int id_supplier { get; set; }

        [ForeignKey("id_product")]
        public virtual Product Product { get; set; }
        [ForeignKey("id_supplier")]
        public virtual Supplier Supplier { get; set; }
    }
}