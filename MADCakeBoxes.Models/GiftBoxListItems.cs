using MADCakeBoxes.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MADCakeBoxes.Models
{
    public class GiftBoxListItems
    {
        private GiftBox giftBox = new GiftBox();
        public int GiftBoxId { get; set; }

        //[ForeignKey(nameof(Cake))]
        public int CakeId { get; set; }
        //public virtual Cake Cake { get; set; }

        public string Occasion { get; set; }
        

        public int NumInInventory { get; set; }

        public double GiftBoxCost
        {

            get
            {
                double BasicBoxCost = 40.00;


                List<int> Inserts = new List<int>();
                int TotalInserts = Inserts.Count;

                if (giftBox.Roses == true)
                {
                    Inserts.Add(1);
                }
                if (giftBox.Pictures == true)
                {
                    Inserts.Add(1);
                }
                if (giftBox.Butterflies == true)
                {
                    Inserts.Add(1);
                }
                return BasicBoxCost + (TotalInserts * 5.00);

            }
        }
    }
}
