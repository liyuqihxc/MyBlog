using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.App;
using MyBlog.Common;
using MyBlog.Models;
using Newtonsoft.Json.Linq;

namespace MyBlog.Controllers
{
    [Route("api/[controller]"), AllowAnonymous]
    public class AttachmentsController : Controller
    {
        private AttachmentsApp _AttachmentsApp { get; }

        public AttachmentsController(AttachmentsApp attachmentsApp)
        {
            _AttachmentsApp = attachmentsApp;
        }

        [HttpGet, Route("images")]
        public async Task<IActionResult> GetImage(int id)
        {
            var image = await _AttachmentsApp.GetImageById(id);
            if (image == null)
                return NotFound(new ExceptionModel { Message = "图片不存在。" });
            return File(image.Image, MimeTypeMap.GetMimeType(System.IO.Path.GetExtension(image.Name)));
        }
    }
}
