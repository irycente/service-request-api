using Domain.Dto;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Business.ServiceRequests
{
    public interface IServiceRequestRepository
    {
        IEnumerable<ServiceRequest> GetAll();
        ServiceRequest GetById(Guid id);
        ServiceRequest Create(ServiceRequestCreateDto newRequestInfo);
        void Update(ServiceRequestUpdateDto requestUpdate);
        void Delete(Guid id);
    }
}
