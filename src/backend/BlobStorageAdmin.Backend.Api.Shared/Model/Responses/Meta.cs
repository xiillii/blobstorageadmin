using BlobStorageAdmin.Backend.Api.Shared.Model.Enums;

namespace BlobStorageAdmin.Backend.Api.Shared.Model.Responses;

public class Meta
{
    public string OperationIdentifier { get; set; }
    public ResponseType ResponseStatus { get; set; }
    public DateTimeOffset Date { get; set; }
    public List<Error>? Errors { get; set; }
}
