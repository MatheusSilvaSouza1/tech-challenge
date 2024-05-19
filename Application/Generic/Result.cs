
using FluentValidation.Results;

namespace Application.Generic
{
    public class Result<T>
    {
        public T Value { get; set; }
        public bool IsSuccess { get; private set; }
        public ValidationFailure? ValidationFailure { get; set; }

        public Result(T value, bool isSuccess, ValidationFailure? validationFailure)
        {
            Value = value;
            IsSuccess = isSuccess;
            ValidationFailure = validationFailure;
        }

        public static Result<T> Success(T value)
        {
            return new Result<T>(value, true, null);
        }

        public static Result<T> Failure(ValidationFailure validationFailures)
        {
            return new Result<T>(default(T), false, validationFailures);
        }
    }
}
