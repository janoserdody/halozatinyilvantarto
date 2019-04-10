using BusinessLayer.Interfaces;
using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusinessLayer
{
    public class ErrorService : IErrorService
    {
        private ILogService logService;

        private EventMediator eventMediator;

        public ErrorService(ILogService logService, EventMediator eventMediator)
        {
            this.logService = logService;
            this.eventMediator = eventMediator;
        }

        void IErrorService.Write(IError error)
        {
            eventMediator.Send(error.Message, error.Type);

            // TODO Username az ErrorMessage metódus hívásnál
            logService.ErrorMessage(error.Message);
        }
    }
}
