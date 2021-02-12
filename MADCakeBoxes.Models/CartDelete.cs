using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MADCakeBoxes.Models
{
    public class CartDelete
    {
        private Cake _Cake = new Cake();
        private GiftBox _GiftBox = new GiftBox();

        [Key]
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

        [ForeignKey(nameof(Customer))]
        [Required]
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        [ForeignKey(nameof(GiftBox))]
        [Required]
        public int? GiftBoxId { get; set; }
        public virtual GiftBox GiftBox { get; set; }

        [Required]
        public Guid CartUser { get; set; }
    }
}
