﻿using MADCakeBoxes.Data;
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
        private readonly Guid _cakeId;

        public CakeService(Guid cakeId)
        {
            _cakeId = cakeId;
        }

        public bool CreateCake(CakeCreate model)
        {
            var entity =
                new Cake()
                {
                    UserId = _cakeId,
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
                    .Where(e => e.UserId == _cakeId)
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
    }
}