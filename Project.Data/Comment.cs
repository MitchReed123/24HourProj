using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        //[ForeignKey(nameof(CommentPost))]
        public int PostId {get; set; }
        public Post CommentPost { get; set; }

        [Required]
        public string Text { get; set; }

        public ICollection<Reply> Replies { get; set; }
    }
}
