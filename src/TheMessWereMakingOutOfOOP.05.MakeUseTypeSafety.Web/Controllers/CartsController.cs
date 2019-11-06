using System;
using Microsoft.AspNetCore.Mvc;
using TheMessWereMakingOutOfOOP._05.MakeUseTypeSafety.Web.Domain;
using TheMessWereMakingOutOfOOP._05.MakeUseTypeSafety.Web.Handlers;
using TheMessWereMakingOutOfOOP._05.MakeUseTypeSafety.Web.Models;
using TheMessWereMakingOutOfOOP._05.MakeUseTypeSafety.Web.Shared;

namespace TheMessWereMakingOutOfOOP._05.MakeUseTypeSafety.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {

        [HttpPost("{cartId}/items")]
        public IActionResult AddItemToCart(
            [FromRoute]CartId cartId,
            AddItemToCartModel addItemToCart,
            [FromServices] IRequestHandler<AddItemToCartRequest, Unit> handler)
            => handler
                .Handle(new AddItemToCartRequest(cartId, addItemToCart.ItemId, addItemToCart.Quantity))
                .ToActionResult();

                

        [HttpPut("{cartId}/items/{itemId}")]
        public IActionResult UpdateItemInCart([FromRoute]CartId cartId, [FromRoute]ItemId itemId, UpdateItemInCart updateItemInCart)
            => throw new NotImplementedException();

        [HttpGet("{cartId}")]
        public ActionResult<CartModel> Get([FromRoute] CartId cartId)
            => throw new NotImplementedException();

        [HttpPost]
        public ActionResult<CartModel> CreateCart()
            => throw new NotImplementedException();


        [HttpDelete("{cartId}/items/{itemId}")]
        public IActionResult RemoveItemFromCart([FromRoute]CartId cartId, [FromRoute]ItemId itemId)
            => throw new NotImplementedException();
    }
}