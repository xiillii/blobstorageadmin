using BlobStorageAdmin.Backend.Api.Shared.Entities;
using BlobStorageAdmin.Backend.Api.Shared.Model.Responses;

namespace BlobStorageAdmin.Backend.Api.Business.Helpers;

public static class BusinessExtensions
{
    public static ContainerDto ContainerItemToDto(this ContainerItem item)
    {
        if (item == null)
        {
            return null;
        }
        var response = new ContainerDto
        {
            Name = item.Name,
            IsDeleted = item.IsDeleted,
            VersionId = item.VersionId,
            Properties = item.Properties?.ContainerItemPropertiesToDto()
        };

        return response;
    }

    public static ContainerItemPropertiesDto ContainerItemPropertiesToDto(this ContainerItemProperties prop)
    {
        if(prop == null)
        {
            return null;
        }

        var response = new ContainerItemPropertiesDto
        {
            LastModified = prop.LastModified,
            LeaseStatus = (Shared.Model.Enums.LeaseStatus?)(int?)prop.LeaseStatus,
            LeaseState = (Shared.Model.Enums.LeaseState?)(int?)prop.LeaseState,
            LeaseDuration = (Shared.Model.Enums.LeaseDurationType?)(int?)prop.LeaseDuration,
            PublicAccess = (Shared.Model.Enums.PublicAccessType?)(int?)prop.PublicAccess,
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
