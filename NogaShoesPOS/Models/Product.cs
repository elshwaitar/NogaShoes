using System.ComponentModel.DataAnnotations;
using System;
namespace NogaShoesPOS.Models
    {
    public class Product
        {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [Range(0, 999999.99)]
        public decimal Price { get; set; }

        [Required]
        [Range(0, 9999)]
        public int Stock { get; set; }
        }
    }
