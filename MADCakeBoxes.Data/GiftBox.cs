using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MADCakeBoxes.Data
{
    public class GiftBox
    {

        [Key]
        public int GiftBoxId { get; set; }
        [Required]
        public string Occasion { get; set; }

        [Required]
        public bool? Roses { get; set; }
        [Required]
        public bool? Pictures { get; set; }
        [Required]
        public bool? Butterflies { get; set; }
        public int? NumInInventory { get; set; }

        public double GiftBoxCost
        {

            get
            {
                double BasicBoxCost = 40.00;
                double PicCost=0;
                double RosesCost=0;
                double ButterfliesCost=0;
                //List<int> Inserts = new List<int>();
                //int TotalInserts = Inserts.Count;

                if (Roses == true)
                {
                    RosesCost = 20.00;
                   // Inserts.Add(1);
                }
                if (Pictures == true)
                {
                    
                    PicCost = 5.00;
                    //Inserts.Add(1);
                }
                if(Butterflies == true)
                {
                    ButterfliesCost = 10.00;
                   // Inserts.Add(1);
                }
                return BasicBoxCost + PicCost + RosesCost + ButterfliesCost;// (TotalInserts * 5.00);

            }
        }

        [ForeignKey(nameof(Cake))]
        public int? CakeId { get; set; }

        public virtual Cake Cake { get; set; }

        [Required]
        public Guid GiftBoxUser { get; set; }
    }
}
