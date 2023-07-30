namespace BlobStorageAdmin.Backend.Api.Shared.Model.Responses;

/// <summary>
/// Container list response
/// </summary>
public class ContainerListResponse : BaseResponse
{
    public List<ContainerDto>? Data { get; set; }

    public ContainerListResponse(string operationIdentifier): base(operationIdentifier) { }
}
