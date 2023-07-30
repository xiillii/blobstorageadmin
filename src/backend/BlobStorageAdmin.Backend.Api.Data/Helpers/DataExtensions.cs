using Azure.Storage.Blobs.Models;
using BlobStorageAdmin.Backend.Api.Shared.Entities;

namespace BlobStorageAdmin.Backend.Api.Data.Helpers;

public static class DataExtensions
{
    public static ContainerItem AzureBlobContainerItemToEntity(this BlobContainerItem blob)
    {

        if (blob == null)
            return null;

        var response = new ContainerItem
        {
            Name = blob.Name ?? "",
            IsDeleted = blob.IsDeleted ?? false,
            VersionId = blob.VersionId ?? "",
            Properties = blob.Properties.AzureBlobContainerPropertiesToEntity()
        };

        return response;
    }

    public static ContainerItemProperties? AzureBlobContainerPropertiesToEntity(this BlobContainerProperties prop)
    {
        if (prop == null)
        {
            return null;
        }

        var response = new ContainerItemProperties
        {
            LastModified = prop.LastModified,
            LeaseStatus = (Shared.Entities.Enums.LeaseStatus?)(int?)prop.LeaseStatus,
            LeaseState = (Shared.Entities.Enums.LeaseState?)(int?)prop.LeaseState,
            LeaseDuration = (Shared.Entities.Enums.LeaseDurationType?)(int?)prop.LeaseDuration,
            PublicAccess = (Shared.Entities.Enums.PublicAccessType?)(int?)prop.PublicAccess,
            HasImmutabilityPolicy = prop.HasImmutabilityPolicy ?? false,
            HasLegalHold = prop.HasLegalHold ?? false,
            DefaultEncryptionScope = prop.DefaultEncryptionScope ?? "",
            PreventEncryptionScopeOverride = prop.PreventEncryptionScopeOverride ?? false,
            DeletedOn = prop.DeletedOn,
            RemainingRetentionDays = prop.RemainingRetentionDays,
            ETag = prop.ETag.ToString(),
            HasImmutableStorageWithVersioning = prop.HasImmutableStorageWithVersioning,
            Metadata = prop.Metadata,
        };

        return response;
    }
}
