using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingWeb.Models
{
    public class ProductImage
    {
        [Key]
        public int Id { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }
        public byte[] Image { get; set; }
    }
}