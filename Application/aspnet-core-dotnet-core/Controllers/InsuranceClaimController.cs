using aspnet_core_dotnet_core.Models;

using aspnet_core_dotnet_core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_core_dotnet_core.Controllers
{
    [ExcludeFromCodeCoverage]
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceClaimController : ControllerBase
    {
        private IClaimService _service;
        private IConfiguration _configuration;
        private readonly ILogger<InsuranceClaimController> _logger;

        
        public InsuranceClaimController(IClaimService service, IConfiguration config, ILogger<InsuranceClaimController> logger)
        {
            this._service = service;
            this._configuration = config;
            _logger = logger;
        }
        [HttpGet]
        [Route("getInsurerDetail")]
        public IEnumerable<Insurer> GetInsurerDetails()
        {
            string token = Request.Headers.ToList().FirstOrDefault(x => x.Key == "Authorization").Value;
             HttpContext.Session.SetString("token", token);
            _configuration["Jwt:Token"] = token;
            return _service.GetAllInsurer();
        }

        [HttpGet]
        [Route("getInsurerByPackage")]
        public IEnumerable<Insurer> GetInsurerDtailsByPackage([FromQuery] string packageName)
        {
            string token = Request.Headers.ToList().FirstOrDefault(x => x.Key == "Authorization").Value;
            _configuration["Jwt:Token"] = token;
            return _service.GetAllInsurerByPackage(packageName);
        }

        [HttpPost]
        [Route("initiateClaim")]
        public async Task<double> InitiateClaimRequest([FromBody] InitiateClaim initiateClaim)
        {
            string token = Request.Headers.ToList().FirstOrDefault(x => x.Key == "Authorization").Value;
            HttpContext.Session.SetString("token", token);
            _configuration["Jwt:Token"] = token;
            return await Task.Run(() => _service.GetBalancePayble(initiateClaim.PatientName, initiateClaim.Ailment, initiateClaim.TreatmentPackageName, initiateClaim.InsurerName));
        }
    }
}
