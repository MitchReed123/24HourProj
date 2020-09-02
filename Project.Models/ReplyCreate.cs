﻿using Project.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class ReplyCreate : CommentCreate
    {
        //[ForeignKey(nameof(ReplyComment))]
        public int CommentId { get; set; }
        public Comment ReplyComment { get; set; }
    }
}
