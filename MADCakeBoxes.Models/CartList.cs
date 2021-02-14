using System;
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
        
        public string FullName { get; set; }
        public int CartId { get; set; }

        [Display(Name = "Number of Items in Cart")]
        public int? ItemCount { get; set; }
        [Display(Name = "Total Cost")]
        public double TotalCost
        {
            get
            {
                return _Cake.CakeCost + _GiftBox.GiftBoxCost;

            }
        }
        [Display(Name = "Purchase Date")]
        public DateTime PurchaseDate { get; set; }

        //Cake ingredients
        public string Flavor { get; set; }
        public string Toppings { get; set; }

        //GiftBox
        //public string Occasion { get; set; }
        //public bool? Roses { get; set; }
        //public bool? Pictures { get; set; }

        public bool? Butterflies { get; set; }
        public int CustomerId { get; set; }
        public int? GiftBoxId { get; set; }
    }
}
