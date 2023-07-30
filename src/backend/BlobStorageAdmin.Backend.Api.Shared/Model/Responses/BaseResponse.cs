namespace BlobStorageAdmin.Backend.Api.Shared.Model.Responses;

/// <summary>
/// Base response
/// </summary>
public class BaseResponse
{
    public Meta Meta { get; set; }

    public BaseResponse()
    {
        Meta = new Meta { 
            ResponseStatus = Enums.ResponseType.Fail,
            Date = DateTime.Now,
        };
    }

    public BaseResponse(string operationIdentifier) : this()
    {
        Meta.OperationIdentifier = operationIdentifier;
    }
}
