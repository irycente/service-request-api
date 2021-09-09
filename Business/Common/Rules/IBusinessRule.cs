namespace Business.Common.Rules
{
    public interface IBusinessRule
    {
        string ErrorMessage { get; }
        bool IsValid();
    }
}
