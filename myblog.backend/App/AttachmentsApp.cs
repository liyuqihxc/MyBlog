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
using MyBlog.DataAccess.Entities;
using MyBlog.IRepository;
using MyBlog.Models;

namespace MyBlog.App
{
    public class AttachmentsApp
    {
        private IMapper _Mapper { get; }
        private IBaseRepository<ImageEntity> _ImagesRepository { get; }

        public AttachmentsApp(
            IMapper mapper,
            IBaseRepository<ImageEntity> imagesRepository
        )
        {
            _Mapper = mapper;
            _ImagesRepository = imagesRepository;
        }

        internal Task<ImageEntity> GetImageById(int id)
        {
            return Task<ImageEntity>.Factory.StartNew(() =>
            {
                return _ImagesRepository.Find(id);
            });
        }
    }
}
