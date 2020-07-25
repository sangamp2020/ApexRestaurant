using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApexRestaurant.Mvc.Models
{
    public class Customers
    {
        
            [Key]
            public int Id { get; set; }
            [StringLength(200)]
            public string FirstName { get; set; }
            [StringLength(200)]
            public string LastName { get; set; }
            [StringLength(500)]
            public string Address { get; set; }
            [StringLength(50)]
            public string PhoneRes { get; set; }
            [StringLength(50)]
            public string PhoneMob { get; set; }
            [Column(TypeName = "datetime")]
            public DateTime? EnrollDate { get; set; }
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


