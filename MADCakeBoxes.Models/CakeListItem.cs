using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MADCakeBoxes.Models
{
    public class CakeListItem
    {
        public int CakeId { get; set; }
        public double? CakeCost { get { return 30.00; } }

        public string  Toppings { get; set; }
        public string  Flavor { get; set; }
        public string Icing { get; set; }
        [Display(Name="Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
