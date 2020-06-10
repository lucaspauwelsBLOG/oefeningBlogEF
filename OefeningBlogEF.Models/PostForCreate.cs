using System;

namespace OefeningBlogEF.Models
{
    public class PostForCreate
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}