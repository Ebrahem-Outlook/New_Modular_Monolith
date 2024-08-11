﻿namespace Monolith.Domain.Core.BaseType;

public sealed class Error : ValueObject
{
    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public string Code { get; }

    public string Message { get; }

    public static Error None => new Error(string.Empty, string.Empty);
}
