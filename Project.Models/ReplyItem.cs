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
    public class ReplyItem : CommentItem
    {
        //[ForeignKey(nameof(ReplyComment))]
        public int CommentId { get; set; }

        public CommentItem ReplyComment { get; set; }


    }
}
