﻿using MADCakeBoxes.Data;
using MADCakeBoxes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MADCakeBoxes.Services
{
    public class CartService
    {
        private readonly Guid _cartId;
        public CartService(Guid cartId)
        {
            _cartId = cartId;
        }
        public bool CreateCart(CartCreate model)
        {
            var entity = new Cart()
            {
                CartUser = _cartId,
                GiftBoxId = model.GiftBoxId,
                ItemCount = model.ItemCount,
                PurchaseDate= DateTime.Now,
                CustomerId=model.CustomerId,

            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Carts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public bool UpdateCart(CartEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Carts.Single(e => e.CartId == model.CartId && e.CartUser == _cartId);

                if (model.ItemCount != null)
                {
                    entity.ItemCount = model.ItemCount; 
                }
                if (model.GiftBoxId !=null)
                {
                    entity.GiftBoxId = model.GiftBoxId; 
                }
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteCart(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Carts.Single(e => e.CartId == id && e.CartUser == _cartId);
                ctx.Carts.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        //public IEnumerable<CartList> GetCartList()
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var query = ctx.Carts
        //            .Where(e => e.CartUser == _cartId)
        //            .Select(e => new CartList
        //        {
        //            CartId = e.CartId,
        //            ItemCount = e.ItemCount,
        //            CustomerId = e.CustomerId,
        //            GiftBoxId = e.GiftBoxId,
        //            PurchaseDate = e.PurchaseDate,
        //        });
        //        return query.ToArray();
        //    }
        //}
        public CartDetail GetCartById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Carts.Single(e => e.CartId == id && e.CartUser == _cartId);
                return new CartDetail
                {
                    CustomerId = entity.CustomerId,
                    CartId=entity.CartId,
                    FullName = entity.Customer.FullName,
                    ItemCount = entity.ItemCount,
                    Flavor = entity.GiftBox.Cake.Flavor,
                    Toppings = entity.GiftBox.Cake.Toppings,
                    GiftBoxId = entity.GiftBoxId,
                    Occasion = entity.GiftBox.Occasion,
                    Roses = entity.GiftBox.Roses,
                    Pictures = entity.GiftBox.Pictures,
                    Butterflies = entity.GiftBox.Butterflies,
                    PurchaseDate = entity.PurchaseDate,
                };
            }
        }
        //Not Real World Usage
        //public CartDetail GetCartByPurchaseDate(DateTime date)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var entity = ctx.Carts.Single(e => e.PurchaseDate == date && e.CartUser == _cartId);
        //        return new CartDetail
        //        {
        //            CustomerId = entity.CustomerId,
        //            CartId = entity.CartId,
        //            FullName = entity.Customer.FullName,
        //            ItemCount = entity.ItemCount,
        //            Flavor = entity.GiftBox.Cake.Flavor,
        //            Toppings = entity.GiftBox.Cake.Toppings,
        //            GiftBoxId = entity.GiftBoxId,
        //            Occasion = entity.GiftBox.Occasion,
        //            Roses = entity.GiftBox.Roses,
        //            Pictures = entity.GiftBox.Pictures,
        //            Butterflies = entity.GiftBox.Butterflies,
        //            PurchaseDate = entity.PurchaseDate,
        //        };
        //    }
        //}
    }
}
