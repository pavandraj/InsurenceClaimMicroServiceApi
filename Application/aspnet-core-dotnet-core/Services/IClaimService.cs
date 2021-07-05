using aspnet_core_dotnet_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_core_dotnet_core.Services
{
    public interface IClaimService
    {
        List<Insurer> GetAllInsurer();
        List<Insurer> GetAllInsurerByPackage(string packagename);
        Task<double> GetBalancePayble(string patientName, string ailment, string packageName, string insurer);
    }
}
