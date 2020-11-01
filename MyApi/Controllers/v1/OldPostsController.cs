using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data.Repositories;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebFramework.Api;
using WebFramework.Filters;

namespace MyApi.Controllers.v1
{
    [ApiVersion("1")]
    public class OldPostsController : BaseController
    {
        private readonly IRepository<Post> _repository;

        public OldPostsController(IRepository<Post> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<PostSelectDto>>> Get(CancellationToken cancellationToken)
        {
            var list = await _repository.TableNoTracking.ProjectTo<PostSelectDto>().ToListAsync(cancellationToken);

            return Ok(list);
        }

        [HttpGet("{id:int}")]
        public async Task<ApiResult<PostSelectDto>> Get(int id, CancellationToken cancellationToken)
        {
            var dto = await _repository.TableNoTracking.ProjectTo<PostSelectDto>()
                .SingleOrDefaultAsync(p => p.Id == id, cancellationToken);

            if (dto == null)
                return NotFound();

            return dto;
        }

        [HttpPost]
        public async Task<ApiResult<PostSelectDto>> Create(PostDto dto, CancellationToken cancellationToken)
        {
            var model = dto.ToEntity();

            await _repository.AddAsync(model, cancellationToken);

            var resultDto = await _repository.TableNoTracking.ProjectTo<PostSelectDto>().SingleOrDefaultAsync(p => p.Id == model.Id, cancellationToken);

            return resultDto;
        }

        [HttpPut]
        public async Task<ApiResult<PostSelectDto>> Update(Guid id, PostDto dto, CancellationToken cancellationToken)
        {
            var model = await _repository.GetByIdAsync(cancellationToken, id);

            model = dto.ToEntity(model);

            await _repository.UpdateAsync(model, cancellationToken);

            var resultDto = await _repository.TableNoTracking.ProjectTo<PostSelectDto>().SingleOrDefaultAsync(p => p.Id == model.Id, cancellationToken);

            return resultDto;
        }

        [HttpDelete("{id:int}")]
        public async Task<ApiResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var model = await _repository.GetByIdAsync(cancellationToken, id);
            await _repository.DeleteAsync(model, cancellationToken);

            return Ok();
        }
    }
}
