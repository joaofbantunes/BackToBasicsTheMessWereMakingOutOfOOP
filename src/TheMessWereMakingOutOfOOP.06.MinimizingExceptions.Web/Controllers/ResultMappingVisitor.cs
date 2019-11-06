using System;
using Microsoft.AspNetCore.Mvc;
using TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Domain;
using TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Shared;

namespace TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Controllers
{
    public class ResultMappingVisitor<TValue, TModel> : Result<TValue>.Error.IResultVisitor<ActionResult<TModel>>
    {
        private readonly Func<TValue, TModel> _valueMapper;

        public ResultMappingVisitor(Func<TValue, TModel> valueMapper = null)
        {
            if (valueMapper is null && typeof(TValue) != typeof(TModel))
            {
                throw new ArgumentException("A value mapper is mandatory unless the input type equals output type.");
            }
            
            _valueMapper = valueMapper;
        }
        
        public ActionResult<TModel> Visit(Result<TValue>.Success result)
        {
            if (result is Result<Unit>.Success)
            {
                return new NoContentResult();
            }
            
            return _valueMapper(result.Value);
        }

        public ActionResult<TModel> Visit(Result<TValue>.Error.NotFound result)
            => new NotFoundObjectResult(result.Message);

        public ActionResult<TModel> Visit(Result<TValue>.Error.Invalid result)
            => new BadRequestObjectResult(result.Message);
        
//        public IActionResult Visit(Result<TValue>.Error.Unexpected result)
//            => new ObjectResult(result.Message) {StatusCode = (int) HttpStatusCode.InternalServerError};
    }
}