using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel;
namespace NogaShoesPOS.Models
    {
    public class Cash
        {
        [Key]
        public int Id { get; set; }

        [Required]
        [ReadOnly(true)]
        public int CashSerial { get; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public DateTime Date { get; set; } = DateTime.Now;

        [Required]
        [Range(0, 999999.99)]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [Required]
        [StringLength(100)]
        public string Cashier { get; set; }


        }
    }
