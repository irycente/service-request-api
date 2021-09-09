using Business.ServiceRequests;
using Domain.Contants;
using Domain.Dto;
using Domain.Entities;
using Domain.Exceptions;
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
                throw new NoResourcesAvailableException(ErrorMessages.NO_RESOURCES_AVAILABLE);
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
                throw new ResourceNotFoundException(ErrorMessages.RESOURCE_NOT_FOUND);
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
