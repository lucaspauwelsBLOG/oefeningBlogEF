

        using System.Threading;
        using System.Threading.Tasks;
        using MediatR;
        using Microsoft.EntityFrameworkCore;
        using OefeningBlogEF.Entities;
        using OefeningBlogEF.Infrastructure;

        namespace OefeningBlogEF.Services.Categories
        {
            public class GetPostByIdRequest : IRequest<GetPostByIdResponse>
            {
                public int PostId { get; set; }
            }

            public class GetPostByIdResponse
            {
                public Post Post{ get; set; }
            }

            public class GetPostByIdRequestHandler : IRequestHandler<GetPostByIdRequest, GetPostByIdResponse>
            {
                private readonly IBlogContext _blogContext;

                public GetPostByIdRequestHandler(IBlogContext blogContext)
                {
                    _blogContext = blogContext;
                }

                public async Task<GetPostByIdResponse> Handle(GetPostByIdRequest request, CancellationToken cancellationToken)
                {
                    var post = await _blogContext.Post.Include(p=>p.Category).SingleOrDefaultAsync(p => p.Id == request.PostId, cancellationToken);

                    return new GetPostByIdResponse{Post = post};
                }
            }
        }
    
