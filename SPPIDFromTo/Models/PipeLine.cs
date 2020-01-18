using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPPIDFromTo.Models
{
    public class PipeLine
    {
        #region Properties

        public string SPID { get; set; } = string.Empty;

        public string ItemTag { get; set; } = string.Empty;

        public Dictionary<int, PipeRun> PipeRuns { get; set; } = new Dictionary<int, PipeRun>();

        #endregion

        #region Constructors


        public PipeLine()
        {
        }

        #endregion

        #region Methods


        #endregion
    }
}
