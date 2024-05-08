namespace Avocado.Api.Models
{
    using Microsoft.AspNetCore.Mvc.Filters;

    public class ExceptionMessageModel
    {
        public string StackTrace { get; set; }
        public string Message { get; set; }

        public ExceptionMessageModel(ExceptionContext context)
        {
            StackTrace = context.Exception.StackTrace;
            Message = context.Exception.Message;
        }
    }
}
