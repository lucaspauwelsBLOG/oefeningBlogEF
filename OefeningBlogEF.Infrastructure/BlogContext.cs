using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OefeningBlogEF.Entities;

namespace OefeningBlogEF.Infrastructure
{
    public interface IBlogContext
    {
        DbSet<Category> Categories { get; }
        DbSet<Post> Post { get; }
        
        Task<int> SaveChangesAsync(CancellationToken token);
    }
    
    public class BlogContext: DbContext, IBlogContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Post { get; set; }
        
        public BlogContext(DbContextOptions options) : base(options)
        {
        }
    }
}