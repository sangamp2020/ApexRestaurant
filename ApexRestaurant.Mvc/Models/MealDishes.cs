using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApexRestaurant.Mvc.Models
{
    public partial class MealDishes
    {
        [Key]
        public int MealDishesId { get; set; }
        public int? MealId { get; set; }
        public int? MenuItemId { get; set; }
        [StringLength(60)]
        public string Quantity { get; set; }
        public bool? IsActive { get; set; }
        [StringLength(200)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        [StringLength(200)]
        public string UpdatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
    }
}

