using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApexRestaurant.Mvc.Models
{
    public class Meals
    {
        
            [Key]

            public int MealId { get; set; }

            public int? StaffId { get; set; }

            public int? CustomerId { get; set; }

            [Column("Date_of_Meal", TypeName = "datetime")]
            public DateTime? DateOfMeal { get; set; }
            [Column("Cost_of_Meal")]
            [StringLength(50)]
            public string CostOfMeal { get; set; }
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
