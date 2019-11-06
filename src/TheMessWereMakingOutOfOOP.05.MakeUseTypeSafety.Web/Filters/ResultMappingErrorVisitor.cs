using Microsoft.AspNetCore.Mvc;
using TheMessWereMakingOutOfOOP._05.MakeUseTypeSafety.Web.Domain;

namespace TheMessWereMakingOutOfOOP._05.MakeUseTypeSafety.Web.Filters
{
    public class ResultMappingErrorVisitor : ErrorDetail.IResultVisitor<IActionResult>
    {
        public IActionResult Visit(ErrorDetail.NotFound result)
            => new NotFoundObjectResult(result.Message);

        public IActionResult Visit(ErrorDetail.Invalid result)
            => new BadRequestObjectResult(result.Message);

//        public IActionResult Visit(Error.Unexpected result)
//            => new ObjectResult(result.Message) {StatusCode = (int) HttpStatusCode.InternalServerError};
    }
}