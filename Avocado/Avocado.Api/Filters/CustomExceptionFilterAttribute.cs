namespace Avocado.Api.Filters
{
    using System;
    using System.Net;
    using Application.Exceptions;
    using FluentValidation;
    using Avocado.Api.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            if (context.Exception is ValidationException)
            {
                context.Result = new JsonResult(new ExceptionMessageModel(context));
            }
            else if (context.Exception is EntityNotFoundException)
            {
                context.Result = new JsonResult(new ExceptionMessageModel(context));
            }
            else
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Result = new JsonResult(new ExceptionMessageModel(context));
            }
        }
    }
}
