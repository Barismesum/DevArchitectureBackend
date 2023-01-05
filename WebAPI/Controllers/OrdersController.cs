using Business.Handlers.Orders.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : BaseApiController
    {
        /// <summary>
        /// Add Order.
        /// </summary>
        /// <param name="createOrder"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateOrderCommand createOrder)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(createOrder));
        }

        /// <summary>
        /// Delete Order.
        /// </summary>
        /// <param name="deleteOrder"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteOrderCommand deleteOrder)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(deleteOrder));
        }
    }
}
