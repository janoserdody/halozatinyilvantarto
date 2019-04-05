using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using BusinessLayer.Interfaces;
using DataLayer;
using DataLayer.Interfaces;
using LiteDB;
using Serilog;


namespace BusinessLayer
{
    public class FactorySupport
    {
        public IFrameWork Create(bool isMySQL, LiteRepository repo)
        {
            ILogService logService = new LogService();
            IErrorService errorService = new ErrorService(logService);
            IDataService dataService = new DataService(isMySQL, repo, errorService);
            IMapper mapper = new Mapper();
            IUserService userService = new UserService(dataService, mapper, logService);
            FrameWork frameWork = new FrameWork(dataService, logService, errorService, userService);
            return frameWork;
        }
    }
}
