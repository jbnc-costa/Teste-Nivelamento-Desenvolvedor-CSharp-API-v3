namespace Questao5.Domain.Comum.Result
{
    public class ValidationError
    {
        public string Identifier { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;
        public ValidationSeverity Severity { get; set; }
    }
}
