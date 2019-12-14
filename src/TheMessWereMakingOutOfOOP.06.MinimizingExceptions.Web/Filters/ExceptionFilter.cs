using System;
using System.Net;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Domain;

namespace TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (TryGetDomainExceptionType(context.Exception, out var valueType))
            {
                // ReSharper disable once PossibleNullReferenceException
                var method = GetType()
                    .GetMethod(nameof(MapDomainException), BindingFlags.Static | BindingFlags.NonPublic)
                    .MakeGenericMethod(valueType);
                
                context.Result = method.Invoke(null, new object[]{context.Exception}) as IActionResult;
            }
            else
            {
                // nope, we shouldn't return the exception message to the client, just for demo
                context.Result = new ObjectResult(context.Exception.Message)
                    {StatusCode = (int) HttpStatusCode.InternalServerError};
            }
            context.ExceptionHandled = true;
        }

        private static bool TryGetDomainExceptionType(Exception ex, out Type valueType)
        {
            var exceptionType = ex.GetType();
            if (exceptionType.IsGenericType && exceptionType.GetGenericTypeDefinition() == typeof(DomainException<>))
            {
                valueType = exceptionType.GenericTypeArguments[0];
                return true;
            }

            valueType = null;
            return false;
        }
        
        private static ActionResult<TValue> MapDomainException<TValue>(DomainException<TValue> exception)
            => exception
                .ErrorDetail
                .Accept<ResultErrorMappingVisitor<TValue, TValue>, ActionResult<TValue>>(
                    new ResultErrorMappingVisitor<TValue, TValue>());
    }
}