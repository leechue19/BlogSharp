using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSharp.Models.Tables
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; } 
        public int UserId { get; set; }
    }
}
