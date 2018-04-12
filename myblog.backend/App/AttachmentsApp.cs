using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBlog.Common;
using MyBlog.DataAccess.Models;
using MyBlog.IRepository;
using MyBlog.ViewModels;

namespace MyBlog.App
{
    public class AttachmentsApp
    {
        private IMapper _Mapper { get; }
        private IBaseRepository<ImageModel> _ImagesRepository { get; }

        public AttachmentsApp(
            IMapper mapper,
            IBaseRepository<ImageModel> imagesRepository
        )
        {
            _Mapper = mapper;
            _ImagesRepository = imagesRepository;
        }

        internal Task<ImageModel> GetImageById(int id)
        {
            return Task<ImageModel>.Factory.StartNew(() =>
            {
                return _ImagesRepository.Find(id);
            });
        }
    }
}
