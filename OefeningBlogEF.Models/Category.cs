using System.Collections.Generic;

namespace OefeningBlogEF.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PostCategory> Posts { get; set; }
    }
}