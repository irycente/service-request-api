using Business.ServiceRequests;
using Domain.Dto;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace DataAccess.ServiceRequests.Repositories
{
    public class ServiceRequestMockRepository : IServiceRequestRepository
    {
        private readonly List<ServiceRequest> serviceRequests;

        public ServiceRequestMockRepository(List<ServiceRequest> mockedServiceRequests)
        {
            serviceRequests = mockedServiceRequests;
        }

        public ServiceRequest Create(ServiceRequestCreateDto newRequestInfo)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ServiceRequest> GetAll()
        {
            throw new NotImplementedException();
        }

        public ServiceRequest GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(ServiceRequestUpdateDto requestUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
