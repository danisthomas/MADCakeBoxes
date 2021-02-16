﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MADCakeBoxes.Models
{
    public class CustomerList
    {
        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return ($"{FirstName} {LastName}");
            }
        }

        public string Address { get; set; }

        public string Phone { get; set; }
    }
}
