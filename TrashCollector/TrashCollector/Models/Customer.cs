﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Zipcode")]
        public string Zipcode { get; set; }

        [Display(Name = "Bill")]
        public double Bill { get; set; }

        [Display(Name = "Pickup Day of the Week")]
        public string PickupDay { get; set; }

        [Display(Name = "One time extra pickup day")]
        public DateTime? ExtraPickupDay { get; set; }

        [Display(Name = "First Day of Suspended Period")]
        public DateTime? SuspendStartDay { get; set; }

        [Display(Name = "Last Day of Suspended Period")]
        public DateTime? SuspendEndDay { get; set; } 

        [Display(Name = "Pickup Status")]
        public bool PickupStatus { get; set; } = false;

        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}