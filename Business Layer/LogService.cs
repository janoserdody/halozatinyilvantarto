using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace BusinessLayer
{
    public class LogService : ILogService
    {
        public LogService()
        {
            Log.Information("Application startup.");
        }
        void ILogService.Create(string message, string userName="Anonymous")
        {
                DateTime time = DateTime.Now;
                Log.Information("{Message} user: {UserName}", message, userName);
        }

        void ILogService.ErrorMessage(string message, string userName = "Anonymous")
        {
            DateTime time = DateTime.Now;
            Log.Warning("{Message} user: {UserName}", message, userName);
        }
    }
}
