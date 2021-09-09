using Domain.Enums;
using System;
using System.Collections.Generic;

namespace Domain.Entities.Mocks
{
    public static class ServiceRequestMocks
    {
        public static List<ServiceRequest> ServiceRequests => new()
        {
            new ServiceRequest
            {
                Id = Guid.Parse("c8ba7773-51b0-415d-a949-600f2a9c1a15"),
                BuildingCode = "COH",
                Description = "Please turn up the AC in suite 1200D. It is too hot here.",
                CurrentStatus = CurrentStatus.Created,
                CreatedBy = "Nik Patel",
                CreatedDate = new DateTime(2021, 8, 31, 15, 20, 05),
                LastModifiedBy = "Jane Doe",
                LastModifiedDate = new DateTime(2021, 9, 1, 10, 30, 10)
            },
            new ServiceRequest
            {
                Id = Guid.Parse("a0c5a0a4-0b58-4aec-ba96-239870033995"),
                BuildingCode = "AJC",
                Description = "Please turn down the AC in suite 1400E. It is too cold here.",
                CurrentStatus = CurrentStatus.InProgress,
                CreatedBy = "Mike Johnson",
                CreatedDate = new DateTime(2021, 8, 27, 19, 30, 06),
                LastModifiedBy = "Alice Evans",
                LastModifiedDate = new DateTime(2021, 8, 29, 10, 30, 10)
            }
        };
    }
}
