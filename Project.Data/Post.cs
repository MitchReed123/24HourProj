using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Author))]
        public int UserID { get; set; }
        public User Author { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
    }
}
