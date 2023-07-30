namespace BlobStorageAdmin.Backend.Api.Shared.Model.Responses;

/// <summary>
/// Container data
/// </summary>
public class ContainerDto
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
    public ContainerItemPropertiesDto? Properties { get; set; }
}
