using Application.Contracts;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Patients.Commands.CreatePatient
{
    public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, CreatePatientCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Patient> _patientRepository;

        public CreatePatientCommandHandler(IMapper mapper, IRepository<Patient> patientRepository)
        {
            _mapper = mapper;
            _patientRepository = patientRepository;
        }

        public async Task<CreatePatientCommandResponse> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            Patient newPatient = _mapper.Map<Patient>(request);
            await _patientRepository.AddAsync(newPatient);
            return new CreatePatientCommandResponse { Success = true, Patient = _mapper.Map<CreatedPatientVm>(newPatient) };
        }
    }
}
