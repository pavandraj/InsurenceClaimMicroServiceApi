using aspnet_core_dotnet_core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace aspnet_core_dotnet_core.Repository
{
    [ExcludeFromCodeCoverage]
    public class InsuranceClaimRepo : IInsuranceClaimRepo
    {

        private IConfiguration _configuration;
        public InsuranceClaimRepo(IConfiguration accessor)
        {
            _configuration = accessor;
        }



        public List<Insurer> GetInsurerList()
        {
            return InsurerData.Insurers;
        }

        [ExcludeFromCodeCoverage]
        public async Task<List<TreatmentPlan>> TreatmentPlans(string patientName, string ailment, string packageName)
        {
            List<TreatmentPlan> plans = new List<TreatmentPlan>();
            TreatmentPlan plan;
            string uriConn = "https://iptreatmentmicroservice.azurewebsites.net/";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(uriConn);

                string token = _configuration["Jwt:Token"];
                client.DefaultRequestHeaders.Add("Authorization", token);
                PatientDetail patient = (from x in InsurerData.Patients
                                         where x.Name == patientName
             && x.PackageName.Contains(packageName) && x.Ailment == ailment
                                         select x).SingleOrDefault<PatientDetail>();
                try
                {
                    var responseMessage = client.GetAsync("api/Treatment/getPlan?" + "Id=" + patient.Id + "&Name=" + patient.Name + "&Age=" + patient.Age + "&Ailment=" + patient.Ailment + "&PackageName=" + patient.PackageName + "&CommencementDate=" + patient.CommencementDate.ToString("yyyy'-'MM'-'dd"));
                    responseMessage.Wait();
                    var result = responseMessage.Result;
                    string responseValue = await result.Content.ReadAsStringAsync();
                    plan = JsonConvert.DeserializeObject<TreatmentPlan>(responseValue);
                    plans.Add(plan);
                }
                catch (Exception e)
                {
                    //_log4net.Error("Exception Occured" + e);
                    return null;
                }

            }
            return plans;

        }
        [ExcludeFromCodeCoverage]
        public async Task<double> InitiateClaim(string patientName, string ailment, string packageName, string insurer)
        {


            List<TreatmentPlan> plans = await TreatmentPlans(patientName, ailment, packageName);


            double balance = 0;




            if (plans.Count != 0)
            {
                TreatmentPlan plan = (from x in plans
                                      where x.Patient.Name == patientName
                  && x.PackageName == packageName && x.AilmentName == ailment
                                      select x).SingleOrDefault<TreatmentPlan>();

                if (plan != null)
                {
                    Insurer insurers = (from x in InsurerData.Insurers
                                        where x.InsurerName == insurer
            && x.InsurerPackageName.Contains(packageName)
                                        select x).SingleOrDefault<Insurer>();
                    int claimsCount = (from x in InsurerData.Insurers select x).Count();
                    if (plan.Cost > insurers.AmountLimit)
                        balance = (plan.Cost) - insurers.AmountLimit;
                    else
                        balance = 0;
                    InsuranceClaim claimDetails = new InsuranceClaim()
                    {

                        ClaimId = ++claimsCount,
                        PlanId = plan.PlanId,
                        PatientName = plan.Patient.Name,
                        AilmentName = plan.AilmentName,
                        PackageName = plan.PackageName,
                        Insurer = insurers,
                        InsurerId = insurers.InsurerId,
                        InsurerName = insurers.InsurerName,
                        PaybleBalance = balance
                    };

                }
            }
            else
            {
                balance = -1;
            }
            return balance;

        }
    }
}
