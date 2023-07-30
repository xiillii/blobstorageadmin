using BlobStorageAdmin.Backend.Api.Shared.Contracts;
using BlobStorageAdmin.Backend.Api.Shared.Entities.InnerRequests;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlobStorageAdmin.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainerController : BaseController
    {
        private readonly IBusinessContainer business;

        public ContainerController(IBusinessContainer bsn)
        {
            business = bsn;
        }

        [HttpGet]
        public async Task<IActionResult> List(CancellationToken cancellationToken = default(CancellationToken))
        {
            var operationIdentifier = Guid.NewGuid().ToString();
            try
            {
                var listRequest = new ContainerListRequest { OperationIdentifier = operationIdentifier };
                var res = await business.GetListAsync(listRequest, cancellationToken);
            
                return ConstructResponse(res);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return ConstructErrorResponse(500, operationIdentifier);
            }
        }
    }
}
