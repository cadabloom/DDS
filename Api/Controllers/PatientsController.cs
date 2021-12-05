using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Patients.Commands.CreatePatient;
using Application.Features.Patients.Commands.DeletePatient;
using Application.Features.Patients.Commands.UpdatePatient;
using Application.Features.Patients.Queries.GetAllPatients;
using Application.Features.Patients.Queries.GetPatientDetail;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class PatientsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientListVm>>> Get()
        {
            var dtos = await _mediator.Send(new GetAllPatientsQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDetailVm>> Get(int id)
        {
            var dto = await _mediator.Send(new GetPatientDetailQuery { PatientId = id });
            return Ok(dto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async  Task<ActionResult<CreatePatientCommandResponse>> Post([FromBody] CreatePatientCommand createPatientCommand)
        {
            var response = await _mediator.Send(createPatientCommand);
            return CreatedAtAction(nameof(Get), new { id = response.Patient.Id }, response);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Put([FromBody] UpdatePatientCommand updatePatientCommand)
        {
            await _mediator.Send(updatePatientCommand);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeletePatientCommand { PatientId = id });
            return NoContent();
        }
    }
}
