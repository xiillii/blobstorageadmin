namespace BlobStorageAdmin.Backend.Api.Shared.Entities.Enums;

public enum LeaseState
{
    /// <summary>
    /// available
    /// </summary>
    Available,

    /// <summary>
    /// leased
    /// </summary>
    Leased,

    /// <summary>
    /// expired
    /// </summary>
    Expired,

    /// <summary>
    /// breaking
    /// </summary>
    Breaking,

    /// <summary>
    /// broken
    /// </summary>
    Broken
}
