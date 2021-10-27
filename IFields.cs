using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lw1
{
    interface IFields
    {
        string FIPS { get; set; }
        string Admin2 { get; set; }
        string Province_State { get; set; }
        string Country_Region { get; set; }
        string Last_Update { get; set; }
        string Lat { get; set; }
        string Long_ { get; set; }
        string Confirmed { get; set; }
        string Deaths { get; set; }
        string Recovered { get; set; }
        string Active { get; set; }
        string Combined_Key { get; set; }
        string Incident_Rate { get; set; }
        string Case_Fatality_Ratio { get; set; }
    }
}
