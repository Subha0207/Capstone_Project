using System;
using System.ComponentModel.DataAnnotations;

namespace PizzaApp.Models
{
    public class Beverage
    {
        [Key]
        public int BeverageId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters.")]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = "Description can't be longer than 500 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Volume is required.")]
        [StringLength(50, ErrorMessage = "Volume can't be longer than 50 characters.")]
        public string Volume { get; set; }

        [Required]
        public bool IsBestSeller { get; set; }

        public string Image { get; set; }

        [Required]
        public DateTime UploadDate { get; set; }
        public bool IsAvailable { get; set; }
        public decimal Cost { get; set; }
    }
}
