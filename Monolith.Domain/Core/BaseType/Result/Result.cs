namespace Monolith.Domain.Core.BaseType.Result;

public class Result
{
    protected Result(bool isSuccess, Error error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; }

    public bool IsFailure => !IsSuccess;

    public Error Error { get; }


    public static Result Success() => new Result(true, Error.None);
}
