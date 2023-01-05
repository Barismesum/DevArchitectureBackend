using Business.Handlers.Consumers.Commands;
using Business.Handlers.Products.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseApiController
    {
        /// <summary>
        /// Add User.
        /// </summary>
        /// <param name="createProduct"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProductCommand createProduct)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(createProduct));
        }

        /// <summary>
        /// Update User.
        /// </summary>
        /// <param name="updateProduct"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommand updateProduct)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(updateProduct));
        }
        /// <summary>
        /// Delete User.
        /// </summary>
        /// <param name="deleteProduct"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteProductCommand deleteProduct)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(deleteProduct));
        }
    }
}
