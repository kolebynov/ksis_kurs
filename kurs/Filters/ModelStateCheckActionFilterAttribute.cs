﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kurs.Services.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Kurs.Filters
{
    public class ModelStateCheckActionFilterAttribute : ActionFilterAttribute
    {
        private readonly IApiHelper _apiHelper;

        public ModelStateCheckActionFilterAttribute(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            if (!context.ModelState.IsValid)
            {
                context.Result = new JsonResult(_apiHelper.GetErrorResultFromModelState(context.ModelState));
                context.HttpContext.Response.StatusCode = 400;
            }
        }
    }
}