using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class AIEventArgs : EventArgs
    {
        public object EventData
        {
            get;
            set;
        }

        public RESONSEMESSAGE ReponseMessage
        {
            get;
            set;
        }
    }

    public enum RESONSEMESSAGE
    {
        LOGIN_SUCCESS = 0,
        SERVERTIME_SUCCESS,
        HOLDINSTRUMENTS_SUCCESS,
        HOLDMARKETDATA_SUCCESS,
        HOLDKLINE_SUCCESS,
        HOLDACCOUNTS_SUCCESS,
        HOLDPOSITION_SUCCESS,
        HOLDORDER_SUCCESS,
        HOLDTRADE_SUCCESS,
        HOLDMAKEORDERACTION_SUCCESS,

        LOGIN_FAILED,
        SERVERTIME_FAILED,
        HOLDINSTRUMENTS_FAILED,
        HOLDMARKETDATA_FAILED,
        HOLDKLINE_FAILED,
        HOLDACCOUNTS_FAILED,
        HOLDPOSITION_FAILED,
        HOLDORDER_FAILED,
        HOLDTRADE_FAILED,
        HOLDMAKEORDERACTION_FAILED,
        HOLDMAKEORDERACTION_EXCEPTION

    };

}
