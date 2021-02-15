using MADCakeBoxes.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MADCakeBoxes.Models
{
    public class GiftBoxDetail
    {
        public int GiftBoxId { get; set; }

        [ForeignKey(nameof(Cake))]
        public int CakeId { get; set; }
        public virtual Cake Cake { get; set; }

        public bool Roses { get; set; }
        public bool Pictures { get; set; }
        public bool Butterflies { get; set; }

        public int NumInInventory { get; set; }

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
