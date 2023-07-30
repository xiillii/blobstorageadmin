using BlobStorageAdmin.Backend.Api.Shared.Entities;

namespace BlobStorageAdmin.Backend.Api.Shared.Contracts;

public interface IStorageData
{
    Task<List<ContainerItem>> ListAsync(int? segmentSize,
                                              string prefix,
                                              CancellationToken cancellationToken = default(CancellationToken));
}
