using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.Models
{
    public class Item
    {

        [Key]
        public int Itemld { get; set; }

        public string BarCode { get; set; }

        public ICollection<User> Users { get; set; }

        
        

    }
}
