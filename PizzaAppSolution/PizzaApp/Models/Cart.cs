﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PizzaApp.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        [Required]
        public int UserId { get; set; }
        [ForeignKey("UserId")]

       public bool IsCheckedOut { get; set; }
        public decimal? TotalPrice { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}
