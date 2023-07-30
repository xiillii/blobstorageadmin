using BlobStorageAdmin.Backend.Api.Business.Helpers;
using BlobStorageAdmin.Backend.Api.Shared.Contracts;
using BlobStorageAdmin.Backend.Api.Shared.Entities.InnerRequests;
using BlobStorageAdmin.Backend.Api.Shared.Model.Responses;
using System.Diagnostics;

namespace BlobStorageAdmin.Backend.Api.Business.Container;

public class Business : IBusinessContainer
{
    private readonly IStorageData storageData;

    public Business(IStorageData sd)
    {
        storageData = sd;
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
                    response.Data.Add(item.ContainerItemToDto());
                }
            }
        }
        catch (Exception ex)
        {

            Debug.WriteLine(ex);
            response.Meta.ResponseStatus = Shared.Model.Enums.ResponseType.Fail;
            response.Meta.Errors = new List<Shared.Model.Error>
            {
                new Shared.Model.Error { Code = "B001_ERROR", Message = "Error building the response" }
            };
        }

        return response;
    }
}
