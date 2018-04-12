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
                .ForMember(vm => vm.Content, opt => opt.MapFrom(m => string.Join("", m.Content.Split(new[]{"\r\n","\r","\n"}, StringSplitOptions.None).Take(15))))
                .ForMember(vm => vm.Announcer, opt => opt.MapFrom(m => m.Announcer.NickName))
                .ForMember(vm => vm.Category, opt => opt.MapFrom(m => m.CategoryID))
                .ForMember(vm => vm.Tags, opt => opt.MapFrom(m => m.TagRelations.Select(t => t.TagID)));
        }
    }
}
