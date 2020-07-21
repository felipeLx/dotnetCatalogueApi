using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspNetEssencial.Models
{
    [Table("Products")]
    public class Product
    {

        [Key]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(80)] 
        public string Name { get; set; }

        [Required]
        [MaxLength(300)] 
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }
        
        [Required]
        public string ImageUrl { get; set; }

        public float Stock { get; set; }

        public DateTime DateCreation { get; set; }

        public Category Category { get; set; }

        public int CategoryId { get; set; }
    }
}