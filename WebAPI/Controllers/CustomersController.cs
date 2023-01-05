using Business.Handlers.Consumers.Commands;
using Business.Handlers.Customers.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : BaseApiController
    {
        /// <summary>
        /// Add User.
        /// </summary>
        /// <param name="createCustomer"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCustomerCommand createCustomer)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(createCustomer));
        }

        /// <summary>
        /// Update User.
        /// </summary>
        /// <param name="updateCustomer"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerCommand updateCustomer)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(updateCustomer));
        }
        /// <summary>
        /// Delete User.
        /// </summary>
        /// <param name="deleteCustomer"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteCustomerCommand deleteCustomer)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(deleteCustomer));
        }
    }
}
