using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniCarSales.Models
{
    public class Vehicle
    {
        public int VehicleID { get; set; }
        [Required]
        [Display(Name = "Vehicle Type")]
        public String VehicleType { get; set; }
        [Required]
        [Display(Name = "Make")]
        public String Make { get; set; }
        [Required]
        [Display(Name = "Model")]
        public String Model { get; set; }
        [Required]
        [Display(Name = "Engine")]
        public String Engine { get; set; }
        [Required]
        [Display(Name = "Doors (number of)")]
        public String Doors { get; set; }
        [Required]
        [Display(Name = "Wheels (number of)")]
        public String Wheels { get; set; }
        [Required]
        [Display(Name = "Body Type")]
        public String SelectedBodyType { get; set; }

    }
}