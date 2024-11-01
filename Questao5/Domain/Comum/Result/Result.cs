namespace Questao5.Domain.Comum.Result
{
    public class Result : IResult
    {
        public object? Value { get; protected set; } = null;
        public Type? ValueType => Value?.GetType();
        public ResultStatus Status { get; private set; }
        public bool IsSuccess => Status == ResultStatus.Ok || Status == ResultStatus.Created;
        public string SuccessMessage { get; protected set; } = string.Empty;
        public IEnumerable<string> Errors { get; protected set; } = new List<string>();
        public List<ValidationError> ValidationErrors { get; protected set; } = new List<ValidationError>();

        public Result(object value) : this(ResultStatus.Ok)
        {
            Value = value;
        }

        protected Result(ResultStatus status)
        {
            Status = status;
        }

        public object? GetValue()
        {
            return Value;
        }

        public static Result Success()
        {
            return new Result(ResultStatus.Ok);
        }

        public static Result Success(string successMessage)
        {
            return new Result(ResultStatus.Ok)
            {
                SuccessMessage = successMessage
            };
        }

        public static Result Create()
        {
            return new Result(ResultStatus.Created);
        }

        public static Result UnprocessableEntity(params string[] errorMessages)
        {
            return new Result(ResultStatus.UnprocessableEntity)
            {
                Errors = errorMessages
            };
        }

        public static Result InternalError(params string[] errorMessages)
        {
            return new Result(ResultStatus.InternalServerError)
            {
                Errors = errorMessages
            };
        }

        public static Result BadRequest(List<ValidationError> validationErrors)
        {
            return new Result(ResultStatus.BadRequest)
            {
                ValidationErrors = validationErrors
            };
        }

        public static Result BadRequest(string identifier, string errorMessage)
        {
            return BadRequest(new List<ValidationError>()
            {
                    new ()
                    {
                        Identifier = identifier,
                        Severity = ValidationSeverity.Error,
                        ErrorMessage = errorMessage,
                    }
            });
        }

        public static Result NotFound()
        {
            return new Result(ResultStatus.NotFound);
        }

        public static Result NotFound(params string[] errorMessages)
        {
            return new Result(ResultStatus.NotFound)
            {
                Errors = errorMessages,
            };
        }

        public static Result Forbidden()
        {
            return new Result(ResultStatus.Forbidden);
        }

        public static Result Forbidden(params string[] errorMessages)
        {
            // o erros messagem são usados internamente pela aplicação.
            return new Result(ResultStatus.Forbidden)
            {
                Errors = errorMessages,
            };
        }

        public static Result Unauthorized()
        {
            return new Result(ResultStatus.Unauthorized);
        }

        public static Result Unauthorized(params string[] errorMessages)
        {
            return new Result(ResultStatus.Unauthorized)
            {
                Errors = errorMessages,
            };
        }
    }

    public class Result<T> : Result
    {
        private T? _value;

        public new T? Value
        {
            get
            {
                return _value;
            }
            protected set
            {
                base.Value = value;
                _value = value;
            }
        }

        public Result(T? value) : base(ResultStatus.Ok)
        {
            Value = value;
        }

        public Result(List<ValidationError> validationErrors) : base(ResultStatus.BadRequest)
        {
            ValidationErrors = validationErrors;
        }

        public Result(ResultStatus status) : base(status) { }

        public static implicit operator T?(Result<T> result)
        {
            return result.Value;
        }

        public static implicit operator Result<T>(T value)
        {
            return Success(value);
        }

        public new T? GetValue()
        {
            return Value;
        }

        public static Result<T> Success(T value)
        {
            return new Result<T>(value);
        }

        public static Result<T> Success(T value, string successMessage)
        {
            return new Result<T>(value)
            {
                SuccessMessage = successMessage
            };
        }

        public static Result<T> Create(T value)
        {
            return new Result<T>(ResultStatus.Created)
            {
                Value = value
            };
        }

        public static new Result<T> UnprocessableEntity(params string[] errorMessages)
        {
            return new Result<T>(ResultStatus.UnprocessableEntity)
            {
                Errors = errorMessages
            };
        }

        public static new Result<T> InternalError(params string[] errorMessages)
        {
            return new Result<T>(ResultStatus.InternalServerError)
            {
                Errors = errorMessages
            };
        }

        public static new Result<T> BadRequest(List<ValidationError> validationErrors)
        {
            return new Result<T>(validationErrors);
        }

        public static new Result<T> BadRequest(string identifier, string errorMessage)
        {
            return BadRequest(new List<ValidationError>()
            {
                    new ()
                    {
                        Identifier = identifier,
                        Severity = ValidationSeverity.Error,
                        ErrorMessage = errorMessage,
                    }
            });
        }

        public static new Result<T> NotFound()
        {
            return new Result<T>(ResultStatus.NotFound);
        }

        public static new Result<T> NotFound(params string[] errorMessages)
        {
            return new Result<T>(ResultStatus.NotFound)
            {
                Errors = errorMessages,
            };
        }

        public static new Result<T> Forbidden()
        {
            return new Result<T>(ResultStatus.Forbidden);
        }

        public static Result<T> Forbidden(params string[] errorMessages)
        {
            // o erros messagem são usados internamente pela aplicação.
            return new Result<T>(ResultStatus.Forbidden)
            {
                Errors = errorMessages,
            };
        }

        public static new Result<T> Unauthorized()
        {
            return new Result<T>(ResultStatus.Unauthorized);
        }

        public static new Result<T> Unauthorized(params string[] errorMessages)
        {
            return new Result<T>(ResultStatus.Unauthorized)
            {
                Errors = errorMessages,
            };
        }
    }
}
