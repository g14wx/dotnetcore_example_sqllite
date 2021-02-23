using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Models
{
    [Table("Provider")]
    public class Provider
    {
        [Key] public int Id { get; set; }
        public String provider { get; set; }
        public List<Product> products;
    }
}