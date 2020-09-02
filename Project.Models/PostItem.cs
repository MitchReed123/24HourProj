using Project.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class PostItem
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
    }
}
