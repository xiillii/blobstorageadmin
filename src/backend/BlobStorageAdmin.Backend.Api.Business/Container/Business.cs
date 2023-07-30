using BlobStorageAdmin.Backend.Api.Business.Helpers;
using BlobStorageAdmin.Backend.Api.Shared.Contracts;
using BlobStorageAdmin.Backend.Api.Shared.Entities.InnerRequests;
using BlobStorageAdmin.Backend.Api.Shared.Model.Responses;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;

namespace BlobStorageAdmin.Backend.Api.Business.Container;

public class Business : IBusinessContainer
{
    private readonly IStorageData storageData;
    private readonly ILogger<Business> logger;

    public Business(IStorageData sd, ILogger<Business> logger)
    {
        storageData = sd;
        this.logger = logger;
    }

    public async Task<ContainerListResponse> GetListAsync(ContainerListRequest request, CancellationToken cancellationToken = default(CancellationToken))
    {
        var response = new ContainerListResponse(request.OperationIdentifier);
        try
        {            
            var result = await storageData.ListAsync(1, "", cancellationToken);
            if (result != null)
            {
                response.Data = new List<ContainerDto>();
                response.Meta.ResponseStatus = Shared.Model.Enums.ResponseType.Ok;

                foreach (var item in result)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    response.Data.Add(item.ContainerItemToDto());
                }
            }
            throw new OperationCanceledException();
        }
        catch (OperationCanceledException cex)
        {
            logger.LogError($"Operation {request.OperationIdentifier}: {cex}");
            response.Meta.ResponseStatus = Shared.Model.Enums.ResponseType.Fail;
            response.Meta.Errors = new List<Shared.Model.Error>
            {
                new Shared.Model.Error { Code = "C001_ERROR", Message = "Operation cancelled" }
            };
        }
        catch (Exception ex)
        {

            logger.LogError($"Operation {request.OperationIdentifier}: {ex}");
            response.Meta.ResponseStatus = Shared.Model.Enums.ResponseType.Fail;
            response.Meta.Errors = new List<Shared.Model.Error>
            {
                new Shared.Model.Error { Code = "B001_ERROR", Message = "Error building the response" }
            };
        }

        return response;
    }
}
