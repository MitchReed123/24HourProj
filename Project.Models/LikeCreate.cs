using Project.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    class LikeCreate
    {
        [Required]
        public Post Post { get; set; }
    }
}
