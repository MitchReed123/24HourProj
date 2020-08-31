using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Author))]
        public int UserID { get; set; }
        public virtual User Author { get; set; }

        [ForeignKey(nameof(CommentPost))]
        public int PostID { get; set; }
        public virtual Post CommentPost{ get; set; }

        [Required]
        public string Text { get; set; }
    }
}
