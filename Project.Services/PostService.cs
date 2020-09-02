using Project.Data;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Project.Services
{
    public class PostService
    {
        private readonly Guid _userId;

        public PostService(Guid userId)
        {
            _userId = userId;
        }



        public bool CreatePost(CreatePost model)
        {
            var entity = new Post()
            {
                OwnerId = _userId,
                Title = model.Title,
                Text = model.Text,
                
            };
        
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PostItem> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Posts
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e => new PostItem
                        {
                            PostId = e.Id,
                            Title = e.Title,
                            Text = e.Text,
                            Comments = e.Comments
                        }
                        );
                return query.ToArray();
            }
        }

        public IEnumerable<PostItem> GetPostById(int id)
        {
            //using (var ctx = new ApplicationDbContext())
            //{
            //    var entity = ctx
            //        .Posts
            //        .Single(e => e.Id == id && e.OwnerId == _userId);
            //    return
            //        new PostItem
            //        {
            //            PostId = entity.Id,
            //            Title = entity.Title,
            //            Text = entity.Text,
            //            Comments = entity.Comments

            //        };
            //}
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Posts
                    .Where(e => e.Id == id && e.OwnerId == _userId)
                    .Select(
                        e => new PostItem
                        {
                            PostId = e.Id,
                            Title = e.Title,
                            Text = e.Text,
                            Comments = e.Comments
                        }
                        );
                return query.ToArray();
            }
        }

        public bool UpdatePost(PostEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Posts
                        .Single(e => e.Id == model.PostId && e.OwnerId == _userId);
                entity.Title = model.Title;
                entity.Text = model.Text;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePost(int postId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Posts.Single(e => e.Id == postId && e.OwnerId == _userId);
                ctx.Posts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
