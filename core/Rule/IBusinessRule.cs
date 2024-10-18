namespace Core.Rule
{
    public interface IBusinessRule
    {
        bool IsBroken();

        string Message { get; }
    }
}
