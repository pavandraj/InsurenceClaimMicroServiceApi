using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_core_dotnet_core.Models
{
    public class PatientDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Ailment { get; set; }
        public string PackageName { get; set; }
        public DateTime CommencementDate { get; set; }
    }
}
