using MADCakeBoxes.Data;
using MADCakeBoxes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MADCakeBoxes.Services
{
    public class GiftBoxService
    {
        private readonly Guid _userId;
        public GiftBoxService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateGiftBox(GiftBoxCreate model)
        {
            var entity = new GiftBox()
            {
                GiftBoxUser = _userId,
                Occasion = model.Occasion,
                Butterflies = model.Butterflies,
                Pictures = model.Pictures,
                Roses = model.Roses,
                NumInInventory = model.NumInInventory,
                CakeId = model.CakeId
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.GiftBoxes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GiftBoxListItems> GetGiftBoxes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.GiftBoxes.Where(e => e.GiftBoxUser == _userId).Select(e => new GiftBoxListItems
                {
                    GiftBoxId = e.GiftBoxId,
                    CakeId = e.CakeId,
                    Occasion = e.Occasion,
                    NumInInventory = e.NumInInventory,
                });
                return query.ToArray();
            }
        }
        public GiftBoxDetail GetGiftBoxById(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.GiftBoxes.Single(e => e.GiftBoxId==Id && e.GiftBoxUser == _userId);
                return new GiftBoxDetail
                {
                    GiftBoxId = entity.GiftBoxId,
                    Occasion = entity.Occasion,
                    CakeId = entity.CakeId,
                    Toppings = entity.Cake.Toppings,
                    Flavor = entity.Cake.Flavor,
                    Icing = entity.Cake.Icing,
                    Roses = entity.Roses,
                    Pictures = entity.Pictures,
                    Butterflies = entity.Butterflies,
                    NumInInventory = entity.NumInInventory,
                };
            }
        }

        public bool UpdateGiftBox(GiftBoxEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.GiftBoxes.Single(e => e.GiftBoxId == model.GiftBoxId && e.GiftBoxUser == _userId);

                if (model.Occasion != null)
                {
                    entity.Occasion = model.Occasion;

                }
                if(model.Roses != null)
                {
                    entity.Roses = model.Roses;
                }
                if(model.Pictures != null)
                {
                    entity.Pictures = model.Pictures;
                }
                if(model.Butterflies != null)
                {
                    entity.Butterflies = model.Butterflies;
                }
                if(model.NumInInventory != null)
                {
                    entity.NumInInventory = model.NumInInventory;
                }
                if(model.CakeId != null)
                {
                    entity.CakeId = model.CakeId;
                }
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteGiftBox(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.GiftBoxes.Single(e => e.GiftBoxId == id && e.GiftBoxUser == _userId);
                ctx.GiftBoxes.Remove(entity);

                return ctx.SaveChanges()==1;
            }
        }


    }
}
