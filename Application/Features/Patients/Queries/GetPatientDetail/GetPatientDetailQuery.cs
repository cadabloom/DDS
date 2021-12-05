using Application.Features.Patients.Queries.GetPatientDetail;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Patients.Queries.GetPatientDetail
{
    public class GetPatientDetailQuery : IRequest<PatientDetailVm>
    {
        public int PatientId { get; set; }
    }
}
