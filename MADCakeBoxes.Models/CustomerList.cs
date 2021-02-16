﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MADCakeBoxes.Data;

namespace MADCakeBoxes.Models
{
    public class CustomerList
    {
        private Customer customer = new Customer();
        public int CustomerId { get; set; }

        public string FullName
        {
            get
            {
                return ($"{customer.FirstName} {customer.LastName}");
            }
        }

        public string Address { get; set; }
    }
}
