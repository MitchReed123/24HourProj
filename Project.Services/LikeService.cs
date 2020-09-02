using Project.Data;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services
{
    public class LikeService
    {
        private readonly Guid _userId;

        public LikeService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateLike(LikeCreate model)
        {
            var entity = new Like()
            {
                UserId = _userId,
                PostId = model.PostId,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Likes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<LikeCreate> GetLikes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Likes.Where(e => e.UserId == _userId).Select(
                        e => new LikeCreate
                        {
                            PostId = e.PostId
                        }
                        );
                return query.ToArray();
            }
        }

        public bool DeleteLike(int likeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Likes.Single(e => e.Id == likeId && e.UserId == _userId);
                ctx.Likes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
