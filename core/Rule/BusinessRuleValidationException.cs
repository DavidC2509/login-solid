using Core.Domain.Exceptions;

namespace Core.Rule
{
    [Serializable]
    public class BusinessRuleValidationException : ServiceException
    {
        public IBusinessRule BrokenRule { get; set; }

        public override int HttpStatusCode { get; }
        public override string ErrorMessage { get; }

        public override Dictionary<string, List<string>> Errors { get; }

        public BusinessRuleValidationException(IBusinessRule brokenRule)
        {
            BrokenRule = brokenRule;
            HttpStatusCode = 400;
            ErrorMessage = "Bussines Validation";
            Errors = new Dictionary<string, List<string>>
            {
                { "Validate", new List<string> { brokenRule.Message } }
            };
        }
    }
}
