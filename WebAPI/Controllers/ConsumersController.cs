using Business.Handlers.Consumers.Commands;
using Business.Handlers.Users.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumersController : BaseApiController
    {
        /// <summary>
        /// Add User.
        /// </summary>
        /// <param name="createConsumer"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateConsumerCommand createConsumer)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(createConsumer));
        }

        /// <summary>
        /// Update User.
        /// </summary>
        /// <param name="updateConsumer"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateConsumerCommand updateConsumer)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(updateConsumer));
        }
        /// <summary>
        /// Delete User.
        /// </summary>
        /// <param name="deleteConsumer"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteConsumerCommand deleteConsumer)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(deleteConsumer));
        }
    }
}
