using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Models
{
    public class User
    {
        [Key]
        public int UserId {get; set; }

       public int ItemId   { get; set; }

       [DataType(DataType.EmailAddress)]

       public string Email { get; set; }

    }
}
