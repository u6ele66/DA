using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lw1
{
    interface IFields
    {
        static string FIPS { get; set; }
        static string Admin2 { get; set; }
        static string Province_State { get; set; }
        static string Country_Region { get; set; }
        static string Last_Update { get; set; }
        static string Lat { get; set; }
        static string Long_ { get; set; }
        static string Confirmed { get; set; }
        static string Deaths { get; set; }
        static string Recovered { get; set; }
        static string Active { get; set; }
        static string Combined_Key { get; set; }
        static string Incident_Rate { get; set; }
        static string Case_Fatality_Ratio { get; set; }
    }
}
