using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoWorks.Core.Diagnostic
{
    public record HealthReportItem (
        string Key, 
        string? Description, 
        TimeSpan Duration, 
        string? Status,
        string? Error, 
        IReadOnlyDictionary<string, object> Data) ;
}
