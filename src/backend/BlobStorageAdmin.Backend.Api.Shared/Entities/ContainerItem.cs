namespace BlobStorageAdmin.Backend.Api.Shared.Entities;

/// <summary>
/// An Storage container.
/// </summary>
public class ContainerItem
{
    /// <summary>
    /// Name.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Deleted.
    /// </summary>
    public bool? IsDeleted { get; set; }

    /// <summary>
    /// Version.
    /// </summary>
    public string? VersionId { get; set; }

    /// <summary>
    /// Properties of a container.
    /// </summary>
    public ContainerItemProperties? Properties { get; set; }
}
