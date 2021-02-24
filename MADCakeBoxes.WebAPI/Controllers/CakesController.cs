using MADCakeBoxes.Data;
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
    public class CakesController : ApiController
    {

        public IHttpActionResult Get()
        {
            CakeService cakeService = CreateCakeService();
            var cakes = cakeService.GetCakes();
            return Ok(cakes);
        }
        public IHttpActionResult Post(CakeCreate cake)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateCakeService();

            if (!service.CreateCake(cake))
                return InternalServerError();

            return Ok();
        }
        private CakeService CreateCakeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var cakeService = new CakeService(userId);
            return cakeService;
        }

       
        public IHttpActionResult Put(CakeEdit cake)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateCakeService();
            if (!service.UpdateCake(cake))
                return InternalServerError();
            return Ok();

        }
        public IHttpActionResult DeleteCake(int id)
        {
            var service = CreateCakeService();
            if (!service.DeleteCake(id))
                return InternalServerError();
            return Ok();
        }
       // [Route("api/Cakes/{id}")]
        public IHttpActionResult GetById(int id)
        {
            CakeService cakeService = CreateCakeService();
            var cake = cakeService.GetCakeById(id);
            return Ok(cake);
        }
    }
}
