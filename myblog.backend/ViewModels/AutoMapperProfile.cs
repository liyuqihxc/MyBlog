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
            CreateMap<PostModel, ArticlePreviewVM>()
                .ForMember(vm => vm.Announcer, opt => opt.MapFrom(m => m.Announcer.NickName))
                .ForMember(vm => vm.Category, opt => opt.MapFrom(m => m.Category.Name))
                .ForMember(vm => vm.Tags, opt => opt.MapFrom(m => m.TagRelations.ToArray().Select(t => t.Tag.Name)));
        }
    }
}
