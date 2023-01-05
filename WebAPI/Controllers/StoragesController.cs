using Business.Handlers.Storages.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoragesController : BaseApiController
    {
        /// <summary>
        /// Add Storage.
        /// </summary>
        /// <param name="createStorage"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateStorageCommand createStorage)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(createStorage));
        }

        /// <summary>
        /// Update Storage.
        /// </summary>
        /// <param name="updateStorage"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateStorageCommand updateStorage)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(updateStorage));
        }
        /// <summary>
        /// Delete Storage.
        /// </summary>
        /// <param name="deleteStorage"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteStorageCommand deleteStorage)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(deleteStorage));
        }
    }
}
