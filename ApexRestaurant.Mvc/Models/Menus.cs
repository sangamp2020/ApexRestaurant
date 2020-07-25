using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ApexRestaurant.Mvc.Models
{
	public class Menus
    {
        [Key]
        public int Id { get; set; }
        [Column("Menu_Name")]
        [StringLength(200)]
        public string MenuName { get; set; }
        [Column("Available_Date_From", TypeName = "datetime")]
        public DateTime? AvailableDateFrom { get; set; }
        [Column("Available_Date_To", TypeName = "datetime")]
        public DateTime? AvailableDateTo { get; set; }
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
