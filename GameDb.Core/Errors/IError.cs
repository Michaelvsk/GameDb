namespace Michaelvsk.GameDb.Core.Errors;

public interface IError
{
    int ErrorCode { get; }
    string Message { get; }
    IError? Inner { get; }
}
