using Azure.Storage.Blobs;
using BlobStorageAdmin.Backend.Api.Data.Helpers;
using BlobStorageAdmin.Backend.Api.Shared.Contracts;
using BlobStorageAdmin.Backend.Api.Shared.Entities;
using Microsoft.Extensions.Configuration;

namespace BlobStorageAdmin.Backend.Api.Data;

public class AzureBlobStorageData : IStorageData
{
    private readonly BlobServiceClient blobServiceClient;

    public AzureBlobStorageData(IConfiguration configuration)
    {
        var connString = configuration.GetSection("Azure:Storage:Credentials:ConnectionString").Value ?? "";
        blobServiceClient = new BlobServiceClient(connString);
    }

    public async Task<List<ContainerItem>> ListAsync(int? segmentSize,
                                              string prefix,
                                              CancellationToken cancellationToken = default(CancellationToken))
    {
        var response = new List<ContainerItem>();
        var result = blobServiceClient.GetBlobContainersAsync(Azure.Storage.Blobs.Models.BlobContainerTraits.Metadata
            , prefix, cancellationToken).AsPages(default, segmentSize);

        await foreach (var containerPage in result)
        {
            foreach (var item in containerPage.Values)
            {
                cancellationToken.ThrowIfCancellationRequested();
                response.Add(item.AzureBlobContainerItemToEntity());
            }
        }

        return response;
    }
}
