using SPPIDFromTo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPPIDFromTo.Models
{
    public class Connector: IConnector
    {
        #region Properties

        public string SPID { get; set; } = string.Empty;
        public string PipeRun_SPID { get; set; } = string.Empty;
        public string SP_ConnectedItem1ID { get; set; } = string.Empty;
        public string SP_ConnectedItem2ID { get; set; } = string.Empty;

        public string End1ItemSymbol { get; set; } = string.Empty;
        public string End2ItemSymbol { get; set; } = string.Empty;


        #endregion

        #region Constructors

        public Connector()
        {
        }

        #endregion

        #region Methods


        #endregion
    }
}
