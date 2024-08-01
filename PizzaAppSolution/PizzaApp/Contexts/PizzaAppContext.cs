using Microsoft.EntityFrameworkCore;
using PizzaApp.Models;
using PizzaApp.Models.Enums;
using PizzaApp.Services;

namespace PizzaApp.Contexts
{
    public class PizzaAppContext : DbContext
    {
     

        public PizzaAppContext(DbContextOptions options) : base(options)
        {
     
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Beverage> Beverages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        public DbSet<CartItem> CartItem { get; set; }
        public DbSet<Crust> Crusts { get; set; }
        public DbSet<Size> Sizes { get; set; } // Add DbSet for Size

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasKey(u => u.UserId);
            modelBuilder.Entity<Payment>().HasKey(p => p.PaymentId);
            modelBuilder.Entity<Pizza>().HasKey(pz => pz.PizzaId);
            modelBuilder.Entity<Beverage>().HasKey(bv => bv.BeverageId);
            modelBuilder.Entity<Order>().HasKey(o => o.OrderId);
            modelBuilder.Entity<Cart>().HasKey(c => c.CartId);
            modelBuilder.Entity<CartItem>().HasKey(ci => ci.CartItemId);
            modelBuilder.Entity<Crust>().HasKey(cr => cr.CrustId);
            modelBuilder.Entity<Size>().HasKey(s => s.SizeId);
            modelBuilder.Entity<Topping>().HasKey(t => t.ToppingId);
         

            var currentDate = DateTime.Now;
            var oneWeekAgo = currentDate.AddDays(-7);

            modelBuilder.Entity<Beverage>().HasData(
                new Beverage
                {
                    BeverageId = 1,
                    Name = "Coca Cola",
                    Description = "A classic soft drink.",
                    Volume = "200ml",
                    Cost = 30m,
                    IsBestSeller = true,
                    Image = "https://images.unsplash.com/photo-1554866585-cd94860890b7?q=80&w=1965&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    UploadDate = new DateTime(2024, 7, 26)
                },
                new Beverage
                {
                    BeverageId = 2,
                    Name = "Pepsi",
                    Description = "Popular cola drink.",
                    Volume = "100ml",
                    Cost = 19m,
                    IsBestSeller = false,
                    Image = "https://images.unsplash.com/photo-1553456558-aff63285bdd1?q=80&w=1887&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    UploadDate = new DateTime(2024, 7, 25)
                },
                new Beverage
                {
                    BeverageId = 3,
                    Name = "Sprite",
                    Description = "Refreshing lemon-lime soda.",
                    Volume = "200ml",
                    Cost = 29m,
                    IsBestSeller = false,
                    Image = "https://images.unsplash.com/photo-1690988109041-458628590a9e?q=80&w=1776&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    UploadDate = new DateTime(2024, 7, 24)
                },
                new Beverage
                {
                    BeverageId = 4,
                    Name = "Fanta",
                    Description = "Fruity orange soda.",
                    Volume = "500ml",
                    Cost = 39m,
                    IsBestSeller = true,
                    Image = "https://media.istockphoto.com/id/509533066/photo/fanta-orange-can.jpg?s=612x612&w=0&k=20&c=sbii6ppPvyuny-v0mx9xizy0QppblYH3sEvPLBr31tA=",
                    UploadDate = new DateTime(2024, 7, 15)
                },
                new Beverage
                {
                    BeverageId = 5,
                    Name = "Mountain Dew",
                    Description = "Citrus-flavored soda.",
                    Volume = "1000ml",
                    Cost = 69m,
                    IsBestSeller = false,
                    Image = "https://images.unsplash.com/photo-1632134547266-ab2cb69602a1?q=80&w=1932&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    UploadDate = new DateTime(2024, 7, 14)
                }
            );

            modelBuilder.Entity<Pizza>().HasData(
                new Pizza
                {
                    PizzaId = 1,
                    Name = "Margherita",
                    Description = "Classic Margherita pizza with fresh mozzarella and basil.",
                    IsVeg = true,
                    UploadDate = currentDate,
                    IsBestSeller = true,
                    Cost = 199m,
                    IsAvailable = true,
                    Image = "https://images.unsplash.com/photo-1544982503-9f984c14501a?q=80&w=1887&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                },
                new Pizza
                {
                    PizzaId = 2,
                    Name = "Pepperoni",
                    Description = "Pepperoni pizza with a crispy crust and rich tomato sauce.",
                    IsVeg = false,
                    UploadDate = currentDate.AddDays(-13),
                    IsBestSeller = true,
                    Cost = 209m,
                    IsAvailable = true,
                    Image = "https://plus.unsplash.com/premium_photo-1661762555601-47d088a26b50?q=80&w=1792&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                },
                new Pizza
                {
                    PizzaId = 3,
                    Name = "Vegetarian Supreme",
                    Description = "Loaded with fresh vegetables and a savory sauce.",
                    IsVeg = true,
                    UploadDate = oneWeekAgo.AddDays(-10),
                    IsBestSeller = false,
                    Cost = 149m,
                    IsAvailable = true,
                    Image = "https://images.unsplash.com/photo-1593560708920-61dd98c46a4e?q=80&w=1935&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                },
                new Pizza
                {
                    PizzaId = 4,
                    Name = "BBQ Chicken",
                    Description = "Grilled chicken with BBQ sauce and red onions.",
                    IsVeg = false,
                    UploadDate = oneWeekAgo.AddDays(-15),
                    IsBestSeller = false,
                    Cost = 299m,
                    IsAvailable = true,
                    Image = "https://images.unsplash.com/photo-1534308983496-4fabb1a015ee?q=80&w=1776&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                },
                new Pizza
                {
                    PizzaId = 5,
                    Name = "Hawaiian",
                    Description = "Sweet pineapple and ham with a cheesy base.",
                    IsVeg = false,
                    UploadDate = oneWeekAgo.AddDays(-10),
                    IsBestSeller = false,
                    Cost = 279m,
                    IsAvailable = true,
                    Image = "https://media.istockphoto.com/id/1442417585/photo/person-getting-a-piece-of-cheesy-pepperoni-pizza.jpg?s=1024x1024&w=is&k=20&c=faq73viCFGvfpKxcBuHcOI8kyT99B-p-jScipke-VuQ="
                }
            );

            modelBuilder.Entity<Crust>().HasData(
                new Crust
                {
                    CrustId = 1,
                    Name = CrustName.Thin,
                  CrustMultiplier=1
                },
                new Crust
                {
                    CrustId = 2,
                    Name = CrustName.Thick,
                    CrustMultiplier = 1.2m
                },
                new Crust
                {
                    CrustId = 3,
                    Name = CrustName.Stuffed,
                    CrustMultiplier = 1.4m
                }
            );

            modelBuilder.Entity<Topping>().HasData(
            
                new Topping
                {
                    ToppingId = 2,
                    Name = ToppingName.Mushrooms,
                    Cost = 29m
                },
                new Topping
                {
                    ToppingId = 3,
                    Name = ToppingName.ExtraCheese,
                    Cost = 15m
                },
                new Topping
                {
                    ToppingId = 4,
                    Name = ToppingName.BlackOlives,
                    Cost = 20m
                }
            );

            modelBuilder.Entity<Size>().HasData(
                new Size
                {
                    SizeId = 1,
                    Name = SizeName.Small,
                   SizeMultiplier=1
                },
                new Size
                {
                    SizeId = 2,
                    Name = SizeName.Medium,
                   SizeMultiplier=1.2m
                },
                new Size
                {
                    SizeId = 3,
                    Name = SizeName.Large,
                   SizeMultiplier=1.4m
                }
            );
        }
    }
}
