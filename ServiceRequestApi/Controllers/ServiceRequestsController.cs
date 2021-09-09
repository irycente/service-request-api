using Business.ServiceRequests;
using Business.ServiceRequests.Validators;
using Domain.Contants;
using Domain.Dto;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Mime;

namespace ServiceRequestApi.Controllers
{
    [Route("api/servicerequest")]
    public class ServiceRequestsController : ControllerBase
    {
        private readonly IServiceRequestRepository repository;
        private readonly ServiceRequestUpdateValidator updateValidator;
        private readonly ServiceRequestCreateValidator createValidator;

        public ServiceRequestsController(
            IServiceRequestRepository repository, 
            ServiceRequestUpdateValidator updateValidator, 
            ServiceRequestCreateValidator createValidator)
        {
            this.repository = repository;
            this.updateValidator = updateValidator;
            this.createValidator = createValidator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ServiceRequest>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetAll()
        {
            try
            {
                var requests = repository.GetAll();

                return Ok(requests);
            }
            catch (NoResourcesAvailableException)
            {
                return NoContent();                
            };
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ServiceRequest), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var request = repository.GetById(id);

                return Ok(request);
            }
            catch (ResourceNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ServiceRequest), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody]ServiceRequestCreateDto requestDto)
        {
            if (requestDto == null)
            {
                return BadRequest(ErrorMessages.EMPTY_REQUEST);
            }

            try
            {
                createValidator.Validate(requestDto);

                var newRequest = repository.Create(requestDto);

                return CreatedAtAction(nameof(GetById), newRequest.Id, newRequest);
            }
            catch (BusinessException ex)
            {
                return BadRequest(ex.Message);                
            }
        }

        [HttpPut]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update([FromBody] ServiceRequestUpdateDto requestDto)
        {
            if (requestDto == null)
            {
                return BadRequest(ErrorMessages.EMPTY_REQUEST);
            }

            try
            {
                updateValidator.Validate(requestDto);

                repository.Update(requestDto);

                return Ok();
            }
            catch (BusinessException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ResourceNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                repository.Delete(id);

                return Ok();
            }
            catch (ResourceNotFoundException ex)
            {
                return NotFound(ex);
            }
        }
    }
}
