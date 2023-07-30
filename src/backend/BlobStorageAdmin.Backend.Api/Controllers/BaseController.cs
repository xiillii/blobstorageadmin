using BlobStorageAdmin.Backend.Api.Shared.Model.Enums;
using BlobStorageAdmin.Backend.Api.Shared.Model.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BlobStorageAdmin.Backend.Api.Controllers
{

    public class BaseController : ControllerBase
    {
        protected IActionResult ConstructErrorResponse(int statusCode, string operationIdentifier)
        {
            var response = new BaseResponse();

            response.Meta.OperationIdentifier = operationIdentifier;
            response.Meta.Errors = new List<Shared.Model.Error>
            {
                new Shared.Model.Error
                {
                    Code = "UNKNOWN_ERROR",
                    Message = "Report to Administrator"
                }
            };

            return StatusCode(statusCode, response);
        }

        protected IActionResult ConstructResponse(BaseResponse response)
        {
            if (response == null || response.Meta.ResponseStatus == ResponseType.Fail)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        protected IActionResult ConstructCreatedResponse(BaseResponse response, string uri, object? value)
        {
            if (response == null || response.Meta.ResponseStatus == ResponseType.Fail)
            {
                return BadRequest(response);
            }

            return Created(uri, value);
        }
    }
}
