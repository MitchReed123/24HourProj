using Project.Data;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services
{
    public class CommentService
    {
        public bool CreateComment(CommentCreate model)
        {
            var entity = new Comment()
            {
                Text = model.Text,
                PostId = model.PostId,
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CommentItem> GetComment()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Comments
                    .Select(e => new CommentItem
                    {
                        Id = e.Id,
                        Text = e.Text,
                        PostId = e.PostId,
                        CommentPost = e.CommentPost
                    }
                    );
                return query.ToArray();
            }
        }

        public Comment GetCommentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Comments
                    .Single(e => e.Id == id);
                return
                    new Comment
                    {
                        Id = entity.Id,
                        Text = entity.Text,
                        PostId = entity.PostId,
                        CommentPost = entity.CommentPost
                    };
            }
        }

        public bool UpdateComment(Comment model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.Id == model.Id);

                entity.Text = model.Text;
                entity.PostId = model.PostId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteComment(int commentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Comments
                    .Single(e => e.Id == commentId);
                ctx.Comments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

