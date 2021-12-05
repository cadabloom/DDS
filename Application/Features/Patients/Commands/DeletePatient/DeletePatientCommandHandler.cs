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

namespace Application.Features.Patients.Commands.DeletePatient
{
    public class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Patient> _patientRepository;

        public DeletePatientCommandHandler(IMapper mapper, IRepository<Patient> patientRepository)
        {
            _mapper = mapper;
            _patientRepository = patientRepository;
        }

        public async Task<Unit> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            Patient patient = await _patientRepository.GetById(request.PatientId);
            await _patientRepository.DeleteAsync(patient);
            return Unit.Value;
        }
    }
}
