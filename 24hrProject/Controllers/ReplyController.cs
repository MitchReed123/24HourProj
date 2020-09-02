using Project.Data;
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
    public class ReplyController : ApiController
    {
        private ReplyService CreateReplyService()
        {
            var replyService = new ReplyService();
            return replyService;
        }

        public IHttpActionResult Get()
        {
            ReplyService replyService = CreateReplyService();
            var replies = replyService.GetReply();
            return Ok(replies);
        }

        public IHttpActionResult Post(ReplyCreate reply)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateReplyService();
            if (!service.CreateReply(reply))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            ReplyService replyService = CreateReplyService();
            var reply = replyService.GetReplyById(id);
            return Ok(reply);
        }

        public IHttpActionResult Put(Reply reply)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateReplyService();

            if (!service.UpdateReply(reply))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateReplyService();

            if (!service.DeleteReply(id))
                return InternalServerError();

            return Ok();
        }
    }
}
