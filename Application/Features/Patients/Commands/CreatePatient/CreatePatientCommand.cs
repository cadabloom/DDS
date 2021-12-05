using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Patients.Commands.CreatePatient
{
    public class CreatePatientCommand : IRequest<CreatePatientCommandResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Notes { get; set; }
    }
}
