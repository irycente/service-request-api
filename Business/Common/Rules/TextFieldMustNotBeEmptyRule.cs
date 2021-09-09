using Domain.Contants;

namespace Business.Common.Rules
{
    public class TextFieldMustNotBeEmptyRule : IBusinessRule
    {
        private readonly string fieldValue;

        public TextFieldMustNotBeEmptyRule(string fieldValue, string fieldName)
        {
            this.fieldValue = fieldValue;

            ErrorMessage = string.Format(ErrorMessages.EMPTY_TEXT_FIELD, fieldName);
        }


        public string ErrorMessage { get; }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(fieldValue);
        }
    }
}
