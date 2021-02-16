using MADCakeBoxes.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MADCakeBoxes.Models
{
    public class GiftBoxEdit
    {
        public int GiftBoxId { get; set; }

        public string Occasion { get; set; }

        public bool? Roses { get; set; }

        public bool? Pictures { get; set; }

        public bool? Butterflies { get; set; }

        public int NumInInventory { get; set; }

        //[ForeignKey(nameof(Cake))]
        public int CakeId { get; set; }
        //public virtual Cake Cake { get; set; }
    }
}
