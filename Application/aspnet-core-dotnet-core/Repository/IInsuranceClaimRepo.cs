using aspnet_core_dotnet_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_core_dotnet_core.Repository
{
    public interface IInsuranceClaimRepo
    {
        List<Insurer> GetInsurerList();
        Task<double> InitiateClaim(string patientName, string ailment, string packageName, string insurer);
    }
}
