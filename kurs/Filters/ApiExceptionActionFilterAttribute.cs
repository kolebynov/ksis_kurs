using Kurs.Exceptions;
using Kurs.Services.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Kurs.Filters
{
    public class ApiExceptionActionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IApiHelper _apiHelper;

        public ApiExceptionActionFilterAttribute(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public override void OnException(ExceptionContext context)
        {
            context.Result = new JsonResult(_apiHelper.GetErrorResultFromException(context.Exception));
            context.HttpContext.Response.StatusCode = context.Exception is ApiException ? 400 : 500;
        }
    }
}