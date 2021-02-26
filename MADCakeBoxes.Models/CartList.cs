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
    public class CartList
    {
        private Cake _Cake = new Cake();
        private GiftBox _GiftBox = new GiftBox();

        public int CartId { get; set; }
        public int? ItemCount { get; set; }
        public double TotalCost
        {
            get
            {
                return _Cake.CakeCost + _GiftBox.GiftBoxCost;

            }
        }
        public DateTime PurchaseDate { get; set; }
        public int CustomerId { get; set; }
        public int? GiftBoxId { get; set; }
    }
}
