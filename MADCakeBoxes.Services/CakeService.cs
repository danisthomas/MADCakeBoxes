using MADCakeBoxes.Data;
using MADCakeBoxes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MADCakeBoxes.Services
{
    public class CakeService
    {
        private readonly Guid _userId;

        public CakeService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCake(CakeCreate model)
        {
            var entity =
                new Cake()
                {
                    UserId = _userId,
                    Flavor = model.Flavor,
                    Toppings = model.Toppings,
                    Icing = model.Icing,
                    
                    
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Cakes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CakeListItem> GetCakes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Cakes
                    .Where(e => e.UserId == _userId)
                    .Select(
                        e =>
                        new CakeListItem
                        {
                            CakeId = e.CakeId,
                            Flavor = e.Flavor,
                            Toppings = e.Toppings
                        }
                     );
                return query.ToArray();

            }
            
        }
        public CakeDetail GetCakeById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Cakes
                        .Single(e => e.CakeId == id && e.UserId == _userId);
                return
                    new CakeDetail
                    {
                        CakeId = entity.CakeId,
                        Flavor = entity.Flavor,
                        Toppings = entity.Toppings,
                        
                    };
            }
        }
        public bool UpdateCake(CakeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                   ctx
                   .Cakes
                   .Single(e => e.CakeId == model.CakeId && e.UserId == _userId);

                entity.Flavor = model.Flavor;
                entity.Icing = model.Icing;
                entity.Toppings = model.Toppings;
               

                return ctx.SaveChanges() == 1;
            }
        }
        //public bool DeleteCake(int cakeId)
        //{
            
        //    using (var ctx = new ApplicationDbContext())
        //    {
                
        //        var entity =
        //            ctx
        //            .Cakes
        //            .Single(e => e.CakeId == cakeId && e.UserId == _userId);
                
        //        ctx.Cakes.Remove(entity);

        //        return ctx.SaveChanges() == 1;
        //    }
        //}

    }
}
