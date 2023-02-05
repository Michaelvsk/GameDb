namespace Michaelvsk.GameDb.Common.Errors;

public interface IError
{
    int ErrorCode { get; }
    string Message { get; }
    IError? Inner { get; }
}
