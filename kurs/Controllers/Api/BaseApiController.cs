﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kurs.ApiResults;
using Kurs.Core.Data;
using Kurs.Core.Domain;
using Kurs.Core.Infrastructure;
using Kurs.Filters;
using Kurs.Models;
using Kurs.Services.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Kurs.Controllers.Api
{
    /// <summary>
    /// Базовый контроллер для всех Api контроллеров.
    /// </summary>
    /// <typeparam name="TEntity">Сущность, с которой работает api контроллер.</typeparam>
    [Produces("application/json")]
    [ServiceFilter(typeof(ModelStateCheckActionFilterAttribute))]
    [IdCheckActionFilter]
    [ServiceFilter(typeof(ApiExceptionActionFilterAttribute))]
    public abstract class BaseApiController<TEntity> : Controller
        where TEntity : BaseEntity
    {
        protected readonly IEntityExpressionsBuilder EntityExpressionsBuilder;
        protected readonly IApiQuery ApiQuery;
        protected readonly IRepository<TEntity> EntityRepository;
        protected readonly IApiHelper ApiHelper;

        /// <summary>
        /// Метод для получения записей.
        /// </summary>
        /// <param name="id">Id объекта (опционально)</param>
        /// <param name="options">Опции запроса (номер страницы, кол-во записей на странице)</param>
        /// <returns></returns>
        [HttpGet("{id?}")]
        public virtual async Task<ApiResult<IEnumerable<TEntity>>> GetItems(Guid id, GetItemsOptions options)
        {
            return await ApiHelper.CreateApiResultFromQueryAsync(EntityRepository.Entities, id, options);
        }

        /// <summary>
        /// Метод для добавления записи.
        /// </summary>
        /// <param name="item">Новая запись</param>
        /// <returns></returns>
        [HttpPost]
        public virtual async Task<IActionResult> AddItem([FromBody] TEntity item)
        {
            await EntityRepository.AddAsync(item);
            TEntity newItem = (await ApiQuery.GetItemsFromQueryAsync(EntityRepository.Entities, item.Id, null)).First();
            return CreatedAtAction("GetItems", new { id = newItem.Id },
                ApiResult.SuccessResult(new[] { newItem }));
        }

        /// <summary>
        /// Метод для обновления записи.
        /// </summary>
        /// <param name="id">Id записи, которую нужно обновить.</param>
        /// <param name="item">Запись, с обновленными полями.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [IdCheckActionFilter]
        public virtual async Task<IActionResult> UpdateItem(Guid id, [FromBody] TEntity item)
        {
            await EntityRepository.UpdateAsync(item);
            TEntity updatedEntity = (await ApiQuery.GetItemsFromQueryAsync(EntityRepository.Entities, id, null)).First();
            return CreatedAtAction("GetItems", new { id }, ApiResult.SuccessResult(new[] { updatedEntity }));
        }

        /// <summary>
        /// Метод для удаления записи.
        /// </summary>
        /// <param name="id">Id записи, к-рую нужно удалить.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [IdCheckActionFilter]
        public virtual async Task<ApiResult> RemoveItem(Guid id)
        {
            await EntityRepository.DeleteAsync(id);
            return new ApiResult { Success = true };
        }

        protected BaseApiController(IRepository<TEntity> repository, IEntityExpressionsBuilder entityExpressionsBuilder, 
            IApiQuery apiQuery, IApiHelper apiHelper)
        {
            EntityRepository = repository ?? throw new ArgumentNullException(nameof(repository));
            EntityExpressionsBuilder = entityExpressionsBuilder ?? throw new ArgumentNullException(nameof(entityExpressionsBuilder));
            ApiQuery = apiQuery ?? throw new ArgumentNullException(nameof(apiQuery));
            ApiHelper = apiHelper ?? throw new ArgumentNullException(nameof(apiHelper));
        }
    }
}