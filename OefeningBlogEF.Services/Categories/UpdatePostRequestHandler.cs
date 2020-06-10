using Microsoft.EntityFrameworkCore;
using OefeningBlogEF.Entities;
using OefeningBlogEF.Infrastructure;

namespace OefeningBlogEF.Services.Categories
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    namespace OefeningBlogEF.Services.Categories
    {
        public class UpdatePostRequest : IRequest<UpdatePostResponse>
        {
            public Post PostToUpdate { get; set; }
        }

        public class UpdatePostResponse
        {
        }

        public class UpdatePostRequestHandler : IRequestHandler<UpdatePostRequest, UpdatePostResponse>
        {
            private readonly IBlogContext _blogContext;

            public UpdatePostRequestHandler(IBlogContext blogContext)
            {
                _blogContext = blogContext;
            }

            public async Task<UpdatePostResponse> Handle(UpdatePostRequest request, CancellationToken cancellationToken)
            {
                var post = await _blogContext.Post.SingleOrDefaultAsync(p => p.Id == request.PostToUpdate.Id, cancellationToken);

                post.Title = request.PostToUpdate.Title;
                post.Description = request.PostToUpdate.Title;
                post.CategoryId = request.PostToUpdate.CategoryId;
                
                await _blogContext.SaveChangesAsync(cancellationToken);
                return new UpdatePostResponse();
            }
        }
    }
}