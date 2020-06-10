using System;

namespace OefeningBlogEF.Models
{
    public class PostCategory
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CategoryName { get; set; }
    }
}