using Microsoft.AspNetCore.Mvc;
using TheMessWereMakingOutOfOOP._05.MakeUseTypeSafety.Web.Shared;

namespace TheMessWereMakingOutOfOOP._05.MakeUseTypeSafety.Web.Controllers
{
    public static class ResultExtensions
    {
        public static ActionResult<TResult> ToActionResult<TResult>(this TResult result)
            => new OkObjectResult(result);
        
        public static IActionResult ToActionResult(this Unit result)
            => new NoContentResult();
    }
}