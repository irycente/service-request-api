using Business.ServiceRequests.Validators;
using Domain.Dto;
using Domain.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Business.Test.ServiceRequests.Validators
{
    [TestClass]
    public class ServiceRequestUpdateValidatorTest
    {
        [TestMethod]
        public void WhenBuildingCodeIsNullShouldThrowBusinessException()
        {
            var update = new ServiceRequestUpdateDto()
            {
                Id = Guid.NewGuid(),
                BuildingCode = null,
                CurrentStatus = 1,
                Description = "A description",
                LastModifiedBy = "A Name"
            };

            var subject = new ServiceRequestUpdateValidator();

            Assert.ThrowsException<BusinessException>(() => subject.Validate(update));
        }

        [TestMethod]
        public void WhenBuildingCodeIsEmptyShouldThrowBusinessException()
        {
            var update = new ServiceRequestUpdateDto()
            {
                Id = Guid.NewGuid(),
                BuildingCode = "",
                CurrentStatus = 1,
                Description = "A description",
                LastModifiedBy = "A Name"
            };

            var subject = new ServiceRequestUpdateValidator();

            Assert.ThrowsException<BusinessException>(() => subject.Validate(update));
        }

        [TestMethod]
        public void WhenCurrentStatusIsNullShouldNotThrowBusinessException()
        {
            var update = new ServiceRequestUpdateDto()
            {
                Id = Guid.NewGuid(),
                BuildingCode = "ABC",
                CurrentStatus = null,
                Description = "A description",
                LastModifiedBy = "A Name"
            };

            var subject = new ServiceRequestUpdateValidator();

            try
            {
                subject.Validate(update);
            }
            catch (BusinessException ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }

        [TestMethod]
        public void WhenCurrentStatusIsInvalidShouldThrowBusinessException()
        {
            var update = new ServiceRequestUpdateDto()
            {
                Id = Guid.NewGuid(),
                BuildingCode = "ABC",
                CurrentStatus = 15,
                Description = "A description",
                LastModifiedBy = "A Name"
            };

            var subject = new ServiceRequestUpdateValidator();

            Assert.ThrowsException<BusinessException>(() => subject.Validate(update));
        }

        [TestMethod]
        public void WhenDescriptionIsNullShouldThrowBusinessException()
        {
            var update = new ServiceRequestUpdateDto()
            {
                Id = Guid.NewGuid(),
                BuildingCode = "ABC",
                CurrentStatus = 1,
                Description = null,
                LastModifiedBy = "A Name"
            };

            var subject = new ServiceRequestUpdateValidator();

            Assert.ThrowsException<BusinessException>(() => subject.Validate(update));
        }

        [TestMethod]
        public void WhenDescriptionIsEmptyShouldThrowBusinessException()
        {
            var update = new ServiceRequestUpdateDto()
            {
                Id = Guid.NewGuid(),
                BuildingCode = "ABC",
                CurrentStatus = 1,
                Description = "",
                LastModifiedBy = "A Name"
            };

            var subject = new ServiceRequestUpdateValidator();

            Assert.ThrowsException<BusinessException>(() => subject.Validate(update));
        }

        [TestMethod]
        public void WhenLastModifiedByIsNullShouldThrowBusinessException()
        {
            var update = new ServiceRequestUpdateDto()
            {
                Id = Guid.NewGuid(),
                BuildingCode = "ABC",
                CurrentStatus = 1,
                Description = "A description",
                LastModifiedBy = null
            };

            var subject = new ServiceRequestUpdateValidator();

            Assert.ThrowsException<BusinessException>(() => subject.Validate(update));
        }

        [TestMethod]
        public void WhenLastModifiedByIsEmptyShouldThrowBusinessException()
        {
            var update = new ServiceRequestUpdateDto()
            {
                Id = Guid.NewGuid(),
                BuildingCode = "ABC",
                CurrentStatus = 1,
                Description = "A description",
                LastModifiedBy = ""
            };

            var subject = new ServiceRequestUpdateValidator();

            Assert.ThrowsException<BusinessException>(() => subject.Validate(update));
        }

        [TestMethod]
        public void WhenUpdateIsValidShouldNotThrowBusinessException()
        {
            var update = new ServiceRequestUpdateDto()
            {
                Id = Guid.NewGuid(),
                BuildingCode = "ABC",
                CurrentStatus = 2,
                Description = "A description",
                LastModifiedBy = "A Name"
            };

            var subject = new ServiceRequestUpdateValidator();

            try
            {
                subject.Validate(update);
            }
            catch (BusinessException ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }
    }
}
