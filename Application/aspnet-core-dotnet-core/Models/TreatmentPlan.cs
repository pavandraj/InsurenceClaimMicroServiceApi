using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_core_dotnet_core.Models
{
    public class TreatmentPlan
    {
        [Key]
        public int PlanId { get; set; }
        public PatientDetail Patient { get; set; }


        public int PatientId { get; set; }
        public string AilmentName { get; set; }
        public string PackageName { get; set; }
        public string TestDetails { get; set; }
        public double Cost { get; set; }
        public string SpecialistName { get; set; }
        public DateTime TreatmentCommencementDate { get; set; }
        public DateTime TreatmentEndDate { get; set; }
    }
}
