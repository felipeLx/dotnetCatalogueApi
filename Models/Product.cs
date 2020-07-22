using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using aspNetEssencial.Validations;

namespace aspNetEssencial.Models
{
    [Table("Products")]
    public class Product
    {

        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage= "Name is required!")]
        [MaxLength(80)] 
        [FirstLetter]
        public string Name { get; set; }

        [Required]
        [MaxLength(300)] 
        public string Description { get; set; }

        [Required]
        [Range(1, 10000, ErrorMessage = "The price should be into {1} and {2}")]
        public decimal Price { get; set; }
        
        [Required]
        public string ImageUrl { get; set; }

        public float Stock { get; set; }

        public DateTime DateCreation { get; set; }

        public Category Category { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext context)
        {
            if(!string.IsNullOrEmpty(this.Name))
            {
                var firstLetter = this.Name[0].ToString();

                if(firstLetter != firstLetter.ToUpper())
                {
                    yield return new ValidationResult("First letter should be in CapsLock!",
                        new[]
                        { nameof(this.Name)}
                        );
                };
            }
        }
    }
}