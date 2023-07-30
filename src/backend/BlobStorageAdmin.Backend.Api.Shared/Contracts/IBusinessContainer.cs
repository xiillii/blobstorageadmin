using BlobStorageAdmin.Backend.Api.Shared.Entities.InnerRequests;
using BlobStorageAdmin.Backend.Api.Shared.Model.Responses;

namespace BlobStorageAdmin.Backend.Api.Shared.Contracts;

public interface IBusinessContainer
{
    Task<ContainerListResponse> GetListAsync(ContainerListRequest request, CancellationToken cancellationToken);
}
