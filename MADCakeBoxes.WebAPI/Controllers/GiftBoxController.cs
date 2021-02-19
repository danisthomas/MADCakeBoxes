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
    [Authorize]
    public class GiftBoxController : ApiController
    {
        public IHttpActionResult Get()
        {
            GiftBoxService giftBoxService = CreateGiftBoxService();
            var giftBox = giftBoxService.GetGiftBoxes();
            return Ok(giftBox);

        }

        public IHttpActionResult Get(int id)
        {
            GiftBoxService giftBoxService = CreateGiftBoxService();
            var giftBox = giftBoxService.GetGiftBoxById(id);
            return Ok(giftBox);
        }

        public IHttpActionResult Post(GiftBoxCreate giftBox)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateGiftBoxService();

            if (!service.CreateGiftBox(giftBox))
            {
                return InternalServerError();
            }
            return Ok();
        }

        public IHttpActionResult Put(GiftBoxEdit giftBox)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateGiftBoxService();

            if (!service.UpdateGiftBox(giftBox))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateGiftBoxService();

            if (!service.DeleteGiftBox(id))
                return InternalServerError();
            return Ok();
        }
        private GiftBoxService CreateGiftBoxService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var giftBoxService = new GiftBoxService(userId);
            return giftBoxService;
        }
    }
}
