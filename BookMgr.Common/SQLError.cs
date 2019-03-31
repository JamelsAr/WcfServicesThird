using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BookMgr.Common
{
    [DataContract]
    public class SQLError
    {
        private string _operation;
        private string _errorMessage;
        public SQLError(string operation, string errorMessage)
        {
            this._operation = operation;
            this._errorMessage = errorMessage;
        }

        [DataMember]
        public string Operation
        {
            get { return _operation; }
            set { _operation = value; }
        }

        [DataMember]
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }

    }
}
