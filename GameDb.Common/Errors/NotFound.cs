using CommunityToolkit.Diagnostics;

namespace Michaelvsk.GameDb.Common.Errors;

public sealed record NotFound : IError
{
    public int ErrorCode { get; } = 404;
    public string Message { get; private set; }
    public IError? Inner { get; private set; }

    public NotFound(string message, IError? inner = null)
    {
        Guard.IsNotNullOrWhiteSpace(message);
        Message = message;

        if (inner != null) Inner = inner;
    }
}
