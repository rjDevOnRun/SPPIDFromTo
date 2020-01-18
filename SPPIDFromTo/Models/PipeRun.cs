using SPPIDFromTo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPPIDFromTo.Models
{
    public class PipeRun: IPipeRun
    {
        #region Properties

        public string SPID { get; set; } = string.Empty;
        public string ItemTag { get; set; } = string.Empty;
        public int Type { get; set; } = 4; // 4=PipeRun, 5=Signalrun
        public int Class { get; set; } = 1; // 1=Piping, 2=Instrument

        public string NominalDiameter { get; set; } = string.Empty;
        public string Fluid { get; set; } = string.Empty;
        public string PipeMaterialsClass { get; set; } = string.Empty;
        public string SequenceNum { get; set; } = string.Empty;
        public string Insulation { get; set; } = string.Empty;
        public string HeatTrace { get; set; } = string.Empty;

        #endregion

        #region Constructors

        public PipeRun()
        {

        }

        #endregion

        #region Methods


        #endregion

    }
}
