using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApexRestaurant.Mvc.Models
{
	public class StaffRoles
    {
		
        [Key]
        [Column("Staff_Roles_Id")]
        public int StaffRolesId { get; set; }
        [Column("Staff_Roles_Description")]
        [StringLength(200)]
        public string StaffRolesDescription { get; set; }
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

