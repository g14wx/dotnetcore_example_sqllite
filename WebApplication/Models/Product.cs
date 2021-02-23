using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int id { get; set; }
        public String title { get; set; }
        public double price { get; set; }
        [ForeignKey("Provider")]
        public int ProviderId { get; set; }
        public Provider provider { get; set; }
    }
}