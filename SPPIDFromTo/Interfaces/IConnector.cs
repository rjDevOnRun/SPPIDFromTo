using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPPIDFromTo.Interfaces
{
    public interface IConnector
    {

        string SPID { get; set; }
        string SP_ConnectedItem1ID { get; set; }
        string SP_ConnectedItem2ID { get; set; }

    }
}
