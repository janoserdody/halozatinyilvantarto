using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class EventMediator
    {
        public event EventHandler<ErrorMessageEventArgs> ErrorMessage;

        protected virtual void OnErrorMessage(ErrorMessageEventArgs e)
        {
            ErrorMessage?.Invoke(this, e);
        }

        public void Send(string message, ErrorType errorType)
        {
            OnErrorMessage(new ErrorMessageEventArgs(message, errorType));
        }
    }
}
