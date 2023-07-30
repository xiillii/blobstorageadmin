using BlobStorageAdmin.Backend.Api.Shared.Entities.Enums;

namespace BlobStorageAdmin.Backend.Api.Shared.Entities;

/// <summary>
/// Properties of a container.
/// </summary>
public class ContainerItemProperties
{
    // <summary>
    /// Last-Modified.
    /// </summary>
    public DateTimeOffset? LastModified { get; set; }

    /// <summary>
    /// LeaseStatus.
    /// </summary>
    public LeaseStatus? LeaseStatus { get; set; }

    /// <summary>
    /// LeaseState.
    /// </summary>
    public LeaseState? LeaseState { get; set; }

    /// <summary>
    /// LeaseDuration.
    /// </summary>
    public LeaseDurationType? LeaseDuration { get; set; }

    /// <summary>
    /// PublicAccess.
    /// </summary>
    public PublicAccessType? PublicAccess { get; set; }

    /// <summary>
    /// HasImmutabilityPolicy.
    /// </summary>
    public bool? HasImmutabilityPolicy { get; set; }

    /// <summary>
    /// HasLegalHold.
    /// </summary>
    public bool? HasLegalHold { get; set; }

    /// <summary>
    /// DefaultEncryptionScope.
    /// </summary>
    public string? DefaultEncryptionScope { get; set; }

    /// <summary>
    /// DenyEncryptionScopeOverride.
    /// </summary>
    public bool? PreventEncryptionScopeOverride { get; set; }

    /// <summary>
    /// DeletedTime.
    /// </summary>
    public DateTimeOffset? DeletedOn { get; set; }

    /// <summary>
    /// RemainingRetentionDays.
    /// </summary>
    public int? RemainingRetentionDays { get; set; }

    /// <summary>
    /// ETag.
    /// </summary>
    public string ETag { get; set; }

    /// <summary>
    /// Metadata.
    /// </summary>
    public IDictionary<string, string>? Metadata { get; set; }

    /// <summary>
    /// If immutable storage with vesrioning is enabled on this container.
    /// </summary>
    public bool? HasImmutableStorageWithVersioning { get; set; }


}
