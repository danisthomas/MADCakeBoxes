using MADCakeBoxes.Models;
using MADCakeBoxes.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MADCakeBoxes.WebAPI.Controllers
{
    public class CartController : ApiController
    {
        public IHttpActionResult GetCart(int id)
        {
            CartService cartService = CreateCartService();
            var cart = cartService.GetCartById(id);
            return Ok(cart);
        }

        //Not Real World Usage
        //[Route("api/cart/purchase")]
        //public IHttpActionResult GetCartByPurchaseDate([FromBody]  DateTime date)
        //{
        //    CartService cartService = CreateCartService();
        //    var cart = cartService.GetCartByPurchaseDate(date);
        //    return Ok(cart);
        //}
        public IHttpActionResult Post(CartCreate cart)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            CartService cartService = CreateCartService();

            if (!cartService.CreateCart(cart)) return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Put(CartEdit cart)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            CartService cartService = CreateCartService();

            if (!cartService.UpdateCart(cart)) return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            CartService service = CreateCartService();

            if (!service.DeleteCart(id)) return InternalServerError();
            return Ok();
        }
        private CartService CreateCartService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var cartService = new CartService(userId);
            return cartService;
        }
    }
}
