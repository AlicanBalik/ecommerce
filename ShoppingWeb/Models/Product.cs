using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingWeb.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        [MaxLength(55, ErrorMessage = "The maximum length must be up to 45 characters only!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Color is required")]
        [MaxLength(45, ErrorMessage = "The maximum length must be up to 24 characters only!")]
        public string Color { get; set; }

        public int CategoryId { get; set; }
        // pants, hat, sweater etc.
        public virtual Category Category { get; set; }

        public int GenderId { get; set; }
        // muski zenski srednji etc.
        public virtual Gender Gender { get; set; }

        public byte[] Image { get; set; }

        public decimal Price { get; set; }
    }
}