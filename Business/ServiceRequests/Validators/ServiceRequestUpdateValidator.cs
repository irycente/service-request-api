using Business.Common;
using Business.Common.Rules;
using Domain.Contants;
using Domain.Dto;
using Domain.Enums;

namespace Business.ServiceRequests.Validators
{
    public class ServiceRequestUpdateValidator
    {
        public void Validate(ServiceRequestUpdateDto requestUpdate)
        {
            var nextStatus = requestUpdate.CurrentStatus.GetValueOrDefault();

            var validator = new BusinessValidator()
                .AddRule(new TextFieldMustNotBeEmptyRule(requestUpdate.BuildingCode, FieldNames.SERVICE_REQUEST_BUILDING_CODE))
                .AddRule(new TextFieldMustNotBeEmptyRule(requestUpdate.Description, FieldNames.SERVICE_REQUEST_DESCRIPTION))
                .AddRule(new TextFieldMustNotBeEmptyRule(requestUpdate.LastModifiedBy, FieldNames.SERVICE_REQUEST_LAST_MODIFIED_BY))
                .AddRule(new ValueMustBePartOfEnumRule<CurrentStatus>(nextStatus, ErrorMessages.INVALID_SERVICE_REQUEST_STATUS), nextStatus != 0);

            validator.Validate();
        }
    }
}
