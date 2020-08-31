using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data
{
    public class Reply : Comment
    {
        [ForeignKey(nameof(ReplyComment))]
        public int CommentID { get; set; }
        public Comment ReplyComment { get; set; }
    }
}
