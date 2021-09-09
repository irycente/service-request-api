using Domain.Dto;
using Domain.Enums;
using System;

namespace Domain.Entities
{
    public class ServiceRequest
    {
        public ServiceRequest()
        {

        }

        // Assumed that Current Status and Created Date are set automatically when creating a new request. Normally I'd validate with BA if not in User Story.
        public ServiceRequest(ServiceRequestCreateDto newRequestInfo)
        {
            Id = Guid.NewGuid();
            BuildingCode = newRequestInfo.BuildingCode;
            Description = newRequestInfo.Description;
            CurrentStatus = CurrentStatus.Created;
            CreatedBy = newRequestInfo.CreatedBy;
            CreatedDate = DateTime.Now;
        }

        public Guid Id { get; set; }
        public string BuildingCode { get; set; }
        public string Description { get; set; }
        public CurrentStatus CurrentStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }

        public void Update(ServiceRequestUpdateDto requestUpdate)
        {
            BuildingCode = requestUpdate.BuildingCode;
            Description = requestUpdate.Description;
            LastModifiedBy = requestUpdate.LastModifiedBy;
            LastModifiedDate = DateTime.Now;

            CurrentStatus = requestUpdate.CurrentStatus != null 
                ? (CurrentStatus)requestUpdate.CurrentStatus 
                : CurrentStatus;
        }
    }
}
