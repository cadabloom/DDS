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

namespace Application.Features.Patients.Queries.GetPatientDetail
{
    public class GetPatientDetailQueryHandler : IRequestHandler<GetPatientDetailQuery, PatientDetailVm>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Patient> _patientRepository;

        public GetPatientDetailQueryHandler(IMapper mapper, IRepository<Patient> patientRepository)
        {
            _mapper = mapper;
            _patientRepository = patientRepository;
        }

        public async Task<PatientDetailVm> Handle(GetPatientDetailQuery request, CancellationToken cancellationToken)
        {
            Patient patient = await _patientRepository.GetById(request.PatientId);
            return _mapper.Map<PatientDetailVm>(patient);
        }
    }
}
