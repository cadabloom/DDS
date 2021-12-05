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

namespace Application.Features.Patients.Queries.GetAllPatients
{
    public class GetAllPatientsQueryHandler : IRequestHandler<GetAllPatientsQuery, List<PatientListVm>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Patient> _patientRepository;

        public GetAllPatientsQueryHandler(IMapper mapper, IRepository<Patient> patientRepository)
        {
            _mapper = mapper;
            _patientRepository = patientRepository;
        }

        public async Task<List<PatientListVm>> Handle(GetAllPatientsQuery request, CancellationToken cancellationToken)
        {
            var patients = await _patientRepository.GetAllAsync();
            return _mapper.Map<List<PatientListVm>>(patients);
        }
    }
}
