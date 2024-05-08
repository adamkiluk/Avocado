namespace Avocado.WebAPI.Models
{
    using Microsoft.AspNetCore.Mvc.Filters;

    public class ExceptionMessageModel(ExceptionContext context)
    {
        public string StackTrace { get; set; } = context.Exception.StackTrace;
        public string Message { get; set; } = context.Exception.Message;
    }
}
