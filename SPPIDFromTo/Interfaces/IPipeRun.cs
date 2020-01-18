using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPPIDFromTo.Interfaces
{
    public interface IPipeRun
    {
        string SPID { get; set; }
        string ItemTag { get; set; }
        int Type { get; set; }
        int Class { get; set; }

        string NominalDiameter { get; set; }
        string Fluid { get; set; }
        string PipeMaterialsClass { get; set; }
        string SeqNumber { get; set; }
        string Insulation { get; set; }
        string HeatTrace { get; set; }


    }
}
