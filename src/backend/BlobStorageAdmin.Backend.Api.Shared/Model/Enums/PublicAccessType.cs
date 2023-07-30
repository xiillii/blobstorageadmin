namespace BlobStorageAdmin.Backend.Api.Shared.Model.Enums;

/// <summary>
/// Specifies whether data in the container may be accessed publicly and the level of access.
/// </summary>
public enum PublicAccessType
{
    /// <summary>
    /// none
    /// </summary>
    None,

    /// <summary>
    /// container
    /// </summary>
    BlobContainer,

    /// <summary>
    /// blob
    /// </summary>
    Blob
}