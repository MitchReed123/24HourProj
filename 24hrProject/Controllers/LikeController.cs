using Microsoft.AspNet.Identity;
using Project.Models;
using Project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _24hrProject.Controllers
{
    [Authorize]
    public class LikeController : ApiController
    {
        private LikeService CreateLikeService()
        {
            return (new LikeService(Guid.Parse(User.Identity.GetUserId())));
        }

        public IHttpActionResult Get()
        {
            LikeService likeService = CreateLikeService();
            var likes = likeService.GetLikes();
            return Ok(likes);
        }

        public IHttpActionResult Post(LikeCreate like)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateLikeService();
            if (!service.CreateLike(like))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateLikeService();
            if (!service.DeleteLike(id))
                return InternalServerError();

            return Ok();
        }
    }
}
    
