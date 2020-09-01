using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data
{
    public class Like
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Post))]
        public int PostID { get; set; }
        public virtual Post Post { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserID { get; set; }
        public virtual User User { get; set; }
    }
}
