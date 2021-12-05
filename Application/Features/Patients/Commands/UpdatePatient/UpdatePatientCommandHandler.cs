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

namespace Application.Features.Patients.Commands.UpdatePatient
{
    public class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Patient> _patientRepository;

        public UpdatePatientCommandHandler(IMapper mapper, IRepository<Patient> patientRepository)
        {
            _mapper = mapper;
            _patientRepository = patientRepository;
        }

        public async Task<Unit> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            Patient patient = await _patientRepository.GetById(request.PatientId);
            if(patient != null)
            {
                _mapper.Map(request, patient);
                await _patientRepository.UpdateAsync(patient);
            }

            return Unit.Value;
        }
    }
}
