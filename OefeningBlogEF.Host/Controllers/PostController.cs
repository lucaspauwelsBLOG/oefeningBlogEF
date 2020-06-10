using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OefeningBlogEF.Entities;
using OefeningBlogEF.Models;
using OefeningBlogEF.Services.Categories;
using OefeningBlogEF.Services.Categories.Delen.Services.Person;
using OefeningBlogEF.Services.Categories.OefeningBlogEF.Services.Categories;
using Category = OefeningBlogEF.Models.Category;

namespace OefeningBlogEF.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController: Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PostController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        
        [HttpGet]
        [Route("GetCategories")]
        public async Task<IActionResult> GetCategories(CancellationToken ct)
        {
            var response = await _mediator.Send(new GetCategoriesRequest(), ct);
            return Ok(_mapper.Map<List<Category>>(response.Categories));
        }
        
        [HttpGet]
        [Route("GetPosts/{categoryId}")]
        public async Task<IActionResult> GetPosts(int categoryId, CancellationToken ct)
        {
            var response = await _mediator.Send(new GetPostRequest{Categoryid = categoryId}, ct);
            return Ok(_mapper.Map<List<PostCategory>>(response.Posts));
        }
        
        [HttpGet]
        [Route("GetPost/{postId}")]
        public async Task<IActionResult> GetPost(int postId, CancellationToken ct)
        {
            var response = await _mediator.Send(new GetPostByIdRequest{PostId = postId}, ct);
            //return Ok(_mapper.Map<PostCategory>(response.Post));
            return Ok(response.Post);
        }
        
        [HttpPost]
        [Route("AddPost")]
        public async Task<IActionResult> AddPost(PostForCreate model, CancellationToken ct)
        {
            await _mediator.Send(new AddPostRequest{PostToAdd = _mapper.Map<Post>(model)}, ct);
            return Ok();
        }
        
        [HttpPut]
        [Route("UpdatePost")]
        public async Task<IActionResult> UpdatePost(PostForUpdate model, CancellationToken ct)
        {
            await _mediator.Send(new UpdatePostRequest{PostToUpdate = _mapper.Map<Post>(model)}, ct);
            return Ok();
        }
        
        
    }
}