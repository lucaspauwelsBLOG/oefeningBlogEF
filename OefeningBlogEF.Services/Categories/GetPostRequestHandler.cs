

    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using OefeningBlogEF.Entities;
    using OefeningBlogEF.Infrastructure;

    namespace OefeningBlogEF.Services.Categories
    {
        using System.Threading;
        using System.Threading.Tasks;
        using MediatR;

        namespace Delen.Services.Person
        {
            public class GetPostRequest : IRequest<GetPostResponse>
            {
                public int Categoryid { get; set; }
            }

            public class GetPostResponse
            {
                public List<Post> Posts{ get; set; }
            }

            public class GetPostRequestHandler : IRequestHandler<GetPostRequest, GetPostResponse>
            {
                private readonly IBlogContext _blogContext;

                public GetPostRequestHandler(IBlogContext blogContext)
                {
                    _blogContext = blogContext;
                }

                public async Task<GetPostResponse> Handle(GetPostRequest request, CancellationToken cancellationToken)
                {
                    var posts = await _blogContext.Post.Where(p => p.CategoryId == request.Categoryid).ToListAsync(cancellationToken);

                    return new GetPostResponse{Posts = posts};
                }
            }
        }
    }
