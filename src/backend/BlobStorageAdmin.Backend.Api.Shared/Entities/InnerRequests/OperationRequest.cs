namespace BlobStorageAdmin.Backend.Api.Shared.Entities.InnerRequests;

public class OperationRequest
{
    public string OperationIdentifier { get; set; }

    public OperationRequest()
    {
        OperationIdentifier = Guid.NewGuid().ToString();
    }
}
