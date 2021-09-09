using System;

namespace Business.Common.Rules
{
    public class ValueMustBePartOfEnumRule<T> : IBusinessRule where T : Enum
    {
        private readonly int value;

        public ValueMustBePartOfEnumRule(int value, string errorMessage)
        {
            this.value = value;
            ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; }

        public bool IsValid()
        {
            return Enum.IsDefined(typeof(T), value);
        }
    }
}
