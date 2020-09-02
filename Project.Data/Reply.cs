﻿using Newtonsoft.Json;
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
    public class Reply : Comment
    {
        //[ForeignKey(nameof(ReplyComment))]
        public int CommentId { get; set; }

        public Comment ReplyComment { get; set; }


    }
}
