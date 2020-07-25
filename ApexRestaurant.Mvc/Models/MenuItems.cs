using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApexRestaurant.Mvc.Models
{
	public class MenuItems
    {
		
        [Key]
        public int MenuItemId { get; set; }
        public int? MenuId { get; set; }
        [Column("Menu_Items_Name")]
        [StringLength(200)]
        public string MenuItemsName { get; set; }
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

