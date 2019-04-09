using Common.Interfaces;
using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common
{
    public class ErrorService : IErrorService
    {
        private ILogService logService;

        public ErrorService(ILogService logService)
        {
            this.logService = logService;
        }

        void IErrorService.Write(IError error)
        {
            MessageBox.Show(error.Message);

            logService.ErrorMessage(error.Message);
        }
    }
}
