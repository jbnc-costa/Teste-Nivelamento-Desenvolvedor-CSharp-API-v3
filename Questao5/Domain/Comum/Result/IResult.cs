namespace Questao5.Domain.Comum.Result
{
    public interface IResult
    {
        ResultStatus Status { get; }

        IEnumerable<string> Errors { get; }

        List<ValidationError> ValidationErrors { get; }

        Type? ValueType { get; }

        object? GetValue();

        bool IsSuccess { get; }
    }
}
