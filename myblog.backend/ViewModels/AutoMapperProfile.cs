using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MyBlog.DataAccess.Models;

namespace MyBlog.ViewModels
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PostModel, ArticleVM>()
                .ForMember(vm => vm.Announcer, opt => opt.MapFrom(m => m.Announcer.NickName))
                .ForMember(vm => vm.Category, opt => opt.MapFrom(m => m.CategoryID))
                .ForMember(vm => vm.Tags, opt => opt.MapFrom(m => m.TagRelations.Select(t => t.TagID)));
        }
    }
}
