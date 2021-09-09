using Business.Common;
using Business.Common.Rules;
using Domain.Contants;
using Domain.Dto;

namespace Business.ServiceRequests.Validators
{
    public class ServiceRequestCreateValidator
    {
        public void Validate(ServiceRequestCreateDto requestUpdate)
        {
            var validator = new BusinessValidator()
                .AddRule(new TextFieldMustNotBeEmptyRule(requestUpdate.BuildingCode, FieldNames.SERVICE_REQUEST_BUILDING_CODE))
                .AddRule(new TextFieldMustNotBeEmptyRule(requestUpdate.Description, FieldNames.SERVICE_REQUEST_DESCRIPTION))
                .AddRule(new TextFieldMustNotBeEmptyRule(requestUpdate.CreatedBy, FieldNames.SERVICE_REQUEST_CREATED_BY));

            validator.Validate();
        }
    }
}
