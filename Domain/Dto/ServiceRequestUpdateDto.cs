using System;

namespace Domain.Dto
{
    /// <summary>
    /// Assumed that this are the fields that the user needs to provide to create a new Service Request. Normally I'd validate with BA if not in User Story.
    /// </summary>
    public class ServiceRequestUpdateDto
    {
        public Guid Id { get; set; }
        public string BuildingCode { get; set; }
        public string Description { get; set; }
        public int? CurrentStatus { get; set; }
        public string LastModifiedBy { get; set; }
    }
}
