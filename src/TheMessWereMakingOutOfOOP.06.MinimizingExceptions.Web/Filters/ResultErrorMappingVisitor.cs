using System;
using Microsoft.AspNetCore.Mvc;
using TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Domain;
using TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Shared;

namespace TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Filters
{
    public struct ResultErrorMappingVisitor<TValue, TModel> : Result<TValue>.Error.IResultVisitor<ActionResult<TModel>>
    {
        public ActionResult<TModel> Visit(Result<TValue>.Success result)
        => throw new NotImplementedException("No success should get here!");

        public ActionResult<TModel> Visit(Result<TValue>.Error.NotFound result)
            => new NotFoundObjectResult(result.Message);

        public ActionResult<TModel> Visit(Result<TValue>.Error.Invalid result)
            => new BadRequestObjectResult(result.Message);
        
//        public IActionResult Visit(Result<TValue>.Error.Unexpected result)
//            => new ObjectResult(result.Message) {StatusCode = (int) HttpStatusCode.InternalServerError};
    }
}