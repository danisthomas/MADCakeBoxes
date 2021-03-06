using MADCakeBoxes.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MADCakeBoxes.Models
{
    public class GiftBoxCreate
    {
        [Required]
        public string Occasion { get; set; }
        [Required]
        public bool Roses { get; set; }
        [Required]
        public bool Pictures { get; set; }

        [Required]
        public bool Butterflies { get; set; }

        public int NumInInventory { get; set; }


        //[ForeignKey(nameof(Cake))]
        public int CakeId { get; set; }

        //public virtual Cake Cake { get; set; }
    }
}
