using Newtonsoft.Json;
using Project.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class CommentItem
    {
        public int Id { get; set; }
        public string Text { get; set; }

        //[ForeignKey("CommentPost")]
        public int PostId { get; set; }
        public Post CommentPost { get; set; }

        public IEnumerable<Reply> Replies { get; set; }
    }
}
