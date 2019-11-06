using System;
using Microsoft.AspNetCore.Mvc;
using TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Domain;
using TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Handlers;
using TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Models;
using TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Shared;

namespace TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        [HttpPost("{cartId}/items")]
        public IActionResult AddItemToCart(
            [FromRoute]CartId cartId,
            AddItemToCartModel addItemToCart,
            [FromServices] IRequestHandler<AddItemToCartRequest, Result<Unit>> handler)
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