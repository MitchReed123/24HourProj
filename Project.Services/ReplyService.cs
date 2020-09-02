using Project.Data;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services
{
    public class ReplyService
    {
        public bool CreateReply(ReplyCreate model)
        {
            var entity = new Reply()
            {
                Text = model.Text,
                PostId = model.PostId,
                CommentId = model.CommentId
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Replies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ReplyItem> GetReply()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Replies
                    .Select(e => new ReplyItem
                    {
                        Id = e.Id,
                        Text = e.Text,
                        PostId = e.PostId,
                        //CommentPost = e.CommentPost,
                        CommentId = e.CommentId,
                        //ReplyComment = e.ReplyComment
                    }
                    );
                return query.ToArray();
            }
        }

        public Reply GetReplyById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Replies
                    .Single(e => e.Id == id);
                return
                    new Reply
                    {
                        Id = entity.Id,
                        Text = entity.Text,
                        PostId = entity.PostId,
                        CommentPost = entity.CommentPost,
                        CommentId = entity.CommentId,
                        ReplyComment = entity.ReplyComment
                    };
            }
        }

        public bool UpdateReply(Reply model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Replies
                        .Single(e => e.Id == model.Id);

                entity.Text = model.Text;
                //entity.PostId = model.PostId;
                entity.CommentId = model.CommentId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteReply(int replyId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Replies
                    .Single(e => e.Id == replyId);
                ctx.Replies.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
