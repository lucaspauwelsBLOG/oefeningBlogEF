
using OefeningBlogEF.Entities;
using OefeningBlogEF.Infrastructure;

namespace OefeningBlogEF.Services.Categories
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    namespace OefeningBlogEF.Services.Categories
    {
        public class AddPostRequest : IRequest<AddPostResponse>
        {
            public Post PostToAdd { get; set; }
        }

        public class AddPostResponse
        {
        }

        public class AddPostRequestHandler : IRequestHandler<AddPostRequest, AddPostResponse>
        {
            private readonly IBlogContext _blogContext;

            public AddPostRequestHandler(IBlogContext blogContext)
            {
                _blogContext = blogContext;
            }

            public async Task<AddPostResponse> Handle(AddPostRequest request, CancellationToken cancellationToken)
            {
                var posts = await _blogContext.Post.AddAsync(request.PostToAdd, cancellationToken);
                await _blogContext.SaveChangesAsync(cancellationToken);
                return new AddPostResponse();
            }
        }
    }
}