using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TheMessWereMakingOutOfOOP._05.MakeUseTypeSafety.Web.Domain;

namespace TheMessWereMakingOutOfOOP._05.MakeUseTypeSafety.Web.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is DomainException domainException)
            {
                context.Result = domainException.ErrorDetail.Accept(new ResultMappingErrorVisitor());
            }
            else
            {
                // nope, we shouldn't return the exception message to the client, just for demo
                context.Result = new ObjectResult(context.Exception.Message)
                    {StatusCode = (int) HttpStatusCode.InternalServerError};
            }
            context.ExceptionHandled = true;
        }
    }
}