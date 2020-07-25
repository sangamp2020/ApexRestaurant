using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ApexRestaurant.Mvc.Models;


namespace ApexRestaurant.Mvc.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApexRestaurant.Mvc.Models.Customers> Customers { get; set; }
        public DbSet<ApexRestaurant.Mvc.Models.MealDishes> MealDishes { get; set; }
        public DbSet<ApexRestaurant.Mvc.Models.Meals> Meals { get; set; }
        public DbSet<ApexRestaurant.Mvc.Models.Menus> Menus { get; set; }
        public DbSet<ApexRestaurant.Mvc.Models.Staffs> Staffs { get; set; }
        public DbSet<ApexRestaurant.Mvc.Models.StaffRoles> StaffRoles { get; set; }
        public DbSet<ApexRestaurant.Mvc.Models.MenuItems> MenuItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = DESKTOP-L0CP8VR\\SQLEXPRESS; Database = ApexRestaurantDB; Trusted_Connection = True;");
        }

    }
}
