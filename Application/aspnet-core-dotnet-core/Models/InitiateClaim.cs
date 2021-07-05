using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_core_dotnet_core.Models
{
    public class InitiateClaim
    {
        public string PatientName { get; set; }
        public string Ailment { get; set; }
        public string TreatmentPackageName { get; set; }
        public string InsurerName { get; set; }
    }
}
