using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspNetEssencial.Models
{
    [Table("Categories")]
    public class Category
    {
        public Category()
        {
            Products = new Collection<Product>();
        }

        [Key]
        public int CategoryId { get; set; }
        
        [Required]
        [MaxLength(80)]        
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}