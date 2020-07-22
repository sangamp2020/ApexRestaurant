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
        public DbSet<ApexRestaurant.Mvc.Models.CustomerViewModel> CustomerViewModel { get; set; }
        public DbSet<ApexRestaurant.Mvc.Models.MealDishViewModel> MealDishViewModel { get; set; }
        public DbSet<ApexRestaurant.Mvc.Models.MealViewModel> MealViewModel { get; set; }
        public DbSet<ApexRestaurant.Mvc.Models.MenuItemViewModel> MenuItemViewModel { get; set; }
        public DbSet<ApexRestaurant.Mvc.Models.MenuViewModel> MenuViewModel { get; set; }
        public DbSet<ApexRestaurant.Mvc.Models.StaffRoleViewModel> StaffRoleViewModel { get; set; }
        public DbSet<ApexRestaurant.Mvc.Models.StaffViewModel> StaffViewModel { get; set; }
    }
}
