using Business.ServiceRequests;
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

        public ServiceRequestsController(IServiceRequestRepository repository)
        {
            this.repository = repository;
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

            // TODO: Apply business validations.

            var newRequest = repository.Create(requestDto);

            return CreatedAtAction(nameof(GetById), newRequest.Id, newRequest);
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
                // TODO: Apply business validations.

                repository.Update(requestDto);

                return Ok();
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
