using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MADCakeBoxes.Models
{
   public class CakeEdit
    {
        public int CakeId { get; set; }

        public string Toppings { get; set; }
        public string Flavor { get; set; }
        public string Icing { get; set; }
        public double? CakeCost { get { return 30.00; } }
        public DateTimeOffset ModifiedUtc { get; set; }
    }
}
