using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ErrorMessageEventArgs : System.EventArgs
    {
        public readonly string message;
        public readonly ErrorType errorType;

        public ErrorMessageEventArgs(string message, ErrorType errorType)
        {
            this.message = message;
            this.errorType = errorType;
        }
    }
}
