using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Patients.Commands.CreatePatient
{
    public class CreatePatientCommandResponse
    {
        public bool Success { get; set; }

        public CreatedPatientVm Patient { get; set; }

    }
}
