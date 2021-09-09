using Business.Common.Rules;
using Domain.Exceptions;
using System.Collections.Generic;

namespace Business.Common
{
    public class BusinessValidator
    {
        private readonly List<IBusinessRule> businessRules = new();

        public BusinessValidator AddRule(IBusinessRule rule, bool condition = true)
        {
            if(rule != null && condition)
            {
                businessRules.Add(rule);
            }

            return this;
        }

        public void Validate()
        {
            foreach(var rule in businessRules)
            {
                Validate(rule);
            }
        }

        private void Validate(IBusinessRule rule)
        {
            if(!rule.IsValid())
            {
                throw new BusinessException(rule.ErrorMessage);
            }
        }
    }
}
