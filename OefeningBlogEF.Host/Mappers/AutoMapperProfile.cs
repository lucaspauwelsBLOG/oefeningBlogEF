using AutoMapper;
using OefeningBlogEF.Entities;
using OefeningBlogEF.Models;
using Category = OefeningBlogEF.Entities.Category;
using CategoryDTO = OefeningBlogEF.Models.Category;

namespace OefeningBlogEF.Host.Mappers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PostForCreate, Post>();
            CreateMap<PostForUpdate, Post>();
            CreateMap<Category, CategoryDTO>();
        }
    }
}