﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MADCakeBoxes.Models
{
    public class CakeCreate
    {
        [Required]
        public string Flavor { get; set; }
        [Required]
        public string Toppings { get; set; }
        [Required]
        public string Icing { get; set; }
        public double CakeCost { get { return 30.00; } }
    }
}
