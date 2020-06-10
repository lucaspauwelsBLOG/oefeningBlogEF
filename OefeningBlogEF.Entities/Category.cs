using System.Collections.Generic;

namespace OefeningBlogEF.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Post> Posts { get; set; }

        public Category()
        {
            Posts = new List<Post>();
        }
    }
}