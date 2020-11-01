using Data.Repositories;
using Entities;
using Microsoft.AspNetCore.Mvc;
using MyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebFramework.Api;

namespace MyApi.Controllers.v2
{
    [ApiVersion("2")]
    public class PostsController : v1.PostsController
    {
        public PostsController(IRepository<Post> repository) : base(repository)
        {
        }

        public override Task<ApiResult<PostSelectDto>> Create(PostDto dto, CancellationToken cancellationToken)
        {
            return base.Create(dto, cancellationToken);
        }

        [NonAction]
        public override Task<ApiResult> Delete(int id, CancellationToken cancellationToken)
        {
            return base.Delete(id, cancellationToken);
        }

        public async override Task<ActionResult<List<PostSelectDto>>> Get(CancellationToken cancellationToken)
        {
            return await Task.FromResult(new List<PostSelectDto>
            {
                new PostSelectDto
                {
                     FullTitle = "FullTitle",
                     AuthorFullName =  "AuthorFullName",
                     CategoryName = "CategoryName",
                     Description = "Description",
                     Title = "Title",
                }
            });
        }

        public async override Task<ApiResult<PostSelectDto>> Get(int id, CancellationToken cancellationToken)
        {
            if (id <= 0)
                return NotFound();
            return await base.Get(id, cancellationToken);
        }

        [HttpGet("Test")]
        public ActionResult Test()
        {
            return Content("This is test");
        }

        public override Task<ApiResult<PostSelectDto>> Update(int id, PostDto dto, CancellationToken cancellationToken)
        {
            return base.Update(id, dto, cancellationToken);
        }
    }
}
