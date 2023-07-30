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
        private readonly ILogger<ContainerController> logger;

        public ContainerController(IBusinessContainer bsn, ILogger<ContainerController> logger)
        {
            business = bsn;
            this.logger = logger;
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
                logger.LogCritical($"Operation {operationIdentifier}: {ex}");
                return ConstructErrorResponse(500, operationIdentifier);
            }
        }
    }
}
