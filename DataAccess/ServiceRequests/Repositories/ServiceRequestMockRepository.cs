using Business.ServiceRequests;
using Domain.Dto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.ServiceRequests.Repositories
{
    public class ServiceRequestMockRepository : IServiceRequestRepository
    {
        private readonly List<ServiceRequest> serviceRequests;

        public ServiceRequestMockRepository(List<ServiceRequest> mockedServiceRequests)
        {
            serviceRequests = mockedServiceRequests;
        }

        public IEnumerable<ServiceRequest> GetAll()
        {
            if(!serviceRequests.Any())
            {
                // TODO: Throw custom exception.
            }

            return serviceRequests;
        }

        public ServiceRequest GetById(Guid id)
        {
            var request = serviceRequests
                .Where(x => x.Id == id)
                .FirstOrDefault();
            
            if(request == null)
            {
                // TODO: Throw custom exception.
            }

            return request;
        }

        public ServiceRequest Create(ServiceRequestCreateDto newRequestInfo)
        {
            var newRequest = new ServiceRequest(newRequestInfo);

            serviceRequests.Add(newRequest);

            return newRequest;
        }

        public void Update(ServiceRequestUpdateDto requestUpdate)
        {
            var requestToUpdate = GetById(requestUpdate.Id);

            requestToUpdate.Update(requestUpdate);
        }

        public void Delete(Guid id)
        {
            var requestToDelete = GetById(id);

            serviceRequests.Remove(requestToDelete);
        }
    }
}
