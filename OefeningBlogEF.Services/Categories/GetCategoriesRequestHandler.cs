using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OefeningBlogEF.Entities;
using OefeningBlogEF.Infrastructure;


namespace OefeningBlogEF.Services.Categories
    {
        public class GetCategoriesRequest : IRequest<GetCategoriesResponse>
        {
        }

        public class GetCategoriesResponse
        {
            public List<Category> Categories{ get; set; }
        }

        public class GetCategoriesRequestHandler : IRequestHandler<GetCategoriesRequest, GetCategoriesResponse>
        {
            private readonly IBlogContext _blogContext;

            public GetCategoriesRequestHandler(IBlogContext blogContext)
            {
                _blogContext = blogContext;
            }

            public async Task<GetCategoriesResponse> Handle(GetCategoriesRequest request, CancellationToken cancellationToken)
            {
                var categories = await _blogContext.Categories.Include(c => c.Posts).ToListAsync(cancellationToken);

                return new GetCategoriesResponse{Categories = categories};
            }
        }
    }
