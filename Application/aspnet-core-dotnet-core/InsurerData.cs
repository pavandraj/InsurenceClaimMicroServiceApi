using aspnet_core_dotnet_core.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_core_dotnet_core
{

    public class InsurerData
    {
        public static List<Insurer> Insurers = new List<Insurer>()
        { new Insurer(){ InsurerId=1, InsurerName="LIC",InsurerPackageName="Basic",AmountLimit=15000,DisbursementDuration=5 },
            new Insurer(){ InsurerId=2, InsurerName="Jevan Life",InsurerPackageName="Special",AmountLimit=25000,DisbursementDuration=3 },
            new Insurer(){ InsurerId=3, InsurerName="HSBC",InsurerPackageName="Basic",AmountLimit=5000,DisbursementDuration=2 },
            new Insurer(){ InsurerId=4, InsurerName="BRILA SUN",InsurerPackageName="Basic",AmountLimit=20000,DisbursementDuration=4 },
        };
        public static List<PatientDetail> Patients = new List<PatientDetail>()
        {
            new PatientDetail()
            {
                  Id =1,
                  Name="Harshita",
                  Age=22,
                  Ailment="Orthopedics",
                  PackageName="Basic",
                  CommencementDate = new DateTime(2021,07,22)
            },
             new PatientDetail()
            {
                  Id =2,
                  Name="Pavan",
                  Age=23,
                  Ailment="Orthopedics",
                  PackageName="Special",
                  CommencementDate = new DateTime(2021,08,12)
            },
              new PatientDetail()
            {
                  Id =3,
                  Name="Pratik",
                  Age=22,
                  Ailment="Urology",
                  PackageName="Special",
                  CommencementDate = new DateTime(2021,09,25)
            },
               new PatientDetail()
            {
                  Id =4,
                  Name="Pranav",
                  Age=22,
                  Ailment="Urology",
                  PackageName="Basic",
                  CommencementDate = new DateTime(2021,03,18)
            }
        };

    }
}
