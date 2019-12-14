using System;
using Microsoft.AspNetCore.Mvc;
using TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Domain;
using TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Shared;

namespace TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Controllers
{
    public static class ResultExtensions
    {
        public static IActionResult ToActionResult<TValue>(this Result<TValue> result)
            => result.Accept<ResultMappingVisitor<TValue, TValue>, ActionResult<TValue>>(
                new ResultMappingVisitor<TValue, TValue>()).Result;
        
        public static ActionResult<TModel> ToActionResult<TValue, TModel>(this Result<TValue> result, Func<TValue, TModel> valueMapper)
            => result.Accept<ResultMappingVisitor<TValue, TModel>, ActionResult<TModel>>(
                new ResultMappingVisitor<TValue, TModel>(valueMapper));
    }
}