using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoWorks.Core.Diagnostic
{
    public record ServerHealthInformation (
        string Status, 
        TimeSpan Duration, 
        List<HealthReportItem> Info);
   
}
