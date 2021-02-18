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
    public class CartDetail
    {
        private Cake _Cake = new Cake();
        private GiftBox _GiftBox = new GiftBox();
       
        public int CustomerId { get; set; }
        public string FullName { get; set; }

        public int CartId { get; set; }

        [Display(Name = "Number of Items in Cart")]
        public int ItemCount { get; set; }

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
        public int CakeId{ get; set; }
        public string Flavor { get; set; }
        public string Toppings { get; set; }
        public double CakeCost { get { return 30.00; } }

        //GiftBox
        public int GiftBoxId { get; set; }
        public string Occasion { get; set; }
        public bool Roses { get; set; }
        public bool Pictures { get; set; }
        public bool Butterflies { get; set; }
        public double GiftBoxCost
        {

            get
            {
                double BasicBoxCost = 40.00;


                List<int> Inserts = new List<int>();
                int TotalInserts = Inserts.Count;

                if (Roses == true)
                {
                    Inserts.Add(1);
                }
                if (Pictures == true)
                {
                    Inserts.Add(1);
                }
                if (Butterflies == true)
                {
                    Inserts.Add(1);
                }
                return BasicBoxCost + (TotalInserts * 5.00);

            }
        }
    }
}
