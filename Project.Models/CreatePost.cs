﻿using Project.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class CreatePost
    {
        [Required]
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
