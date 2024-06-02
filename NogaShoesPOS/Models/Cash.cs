using System.ComponentModel.DataAnnotations;
using System;
namespace NogaShoesPOS.Models
    {
    public class Cash
        {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [Range(0, 999999.99)]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        }
    }
