using BusinessLayer.Interfaces;
using BusinessLayer.Support;
using BusinessLayer.Support._interfaces;
using DataLayer.Interfaces;
using System;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class FrameWork : IFrameWork
    {
        private IDataService dataService;
        private ILogService logService;
        private IErrorService errorService;
        private IRegisterActive registerActive;
        private IUIFactory uiFactory;
        IUserService userService;
        IError error;

        public FrameWork(IDataService dataService,
            ILogService logService, IErrorService errorService, IUserService userService)
        {
            this.dataService = dataService;
            this.logService = logService;
            this.errorService = errorService;
            this.userService = userService;
            registerActive = new RegisterActive(logService, errorService);
            uiFactory = new UIFactory();
        }

        object IFrameWork.GetService(Type type)
        {
            object service = null;

            if (type == typeof(IUIFactory))
            {
                service = uiFactory;
            }
            else if (type == typeof(IErrorService))
            {
                service = errorService;
            }

            return service;
        }

        bool IFrameWork.AddItemActive(IItemActive item)
        {
            bool ok = false;

            string message;

            IError error = dataService.InsertItemActive(item);

            if (!error.IsError)
            {
                message = "Aktív eszköz elmentve " + item.DeviceName;
                ok = true;
                registerActive.Add(item);
            }
            else
            {
                message = error.Message;
            }

            logService.Create(message);

            return ok;
        }

        bool IFrameWork.LoadDatabase()
        {
            IList<IItemActive> itemList = new List<IItemActive>();

            itemList = dataService.GetItemActive();

            foreach (var item in itemList)
            {
                registerActive.Add(item);
            }

            return true;
        }

        IItemActive IFrameWork.GetItemActive(int id)
        {
            IItemActive item = registerActive[id];

            return item; 
        }

        bool IFrameWork.AddItemPassive(IItemPassive item)
        {
            throw new NotImplementedException();
        }

        IItemPassive IFrameWork.GetItemPassive(int id)
        {
            throw new NotImplementedException();
        }

        bool IFrameWork.ModifyItemActive(IItemActive item)
        {
            throw new NotImplementedException();
        }

        bool IFrameWork.ModifyItemPassive(IItemActive item)
        {
            throw new NotImplementedException();
        }

        bool IFrameWork.RemoveItemActive(IItemActive item)
        {
            throw new NotImplementedException();
        }

        bool IFrameWork.RemoveItemPassive(IItemPassive item)
        {
            throw new NotImplementedException();
        }

        bool IFrameWork.RemoveItem(int id)
        {
            throw new NotImplementedException();
        }

        bool IFrameWork.RemoveItemPassive(int id)
        {
            throw new NotImplementedException();
        }

        IItemActive IFrameWork.SearchItem(int id)
        {
            throw new NotImplementedException();
        }

        IItemPassive IFrameWork.SearchItemPassive(int id)
        {
            throw new NotImplementedException();
        }

        IItemActive IFrameWork.SearchItemActive(string search)
        {
            throw new NotImplementedException();
        }

        bool IFrameWork.AddPortActive(int itemID, IPortActive portActive)
        {
            throw new NotImplementedException();
        }

        bool IFrameWork.AddPortPassive(int itemID, IPortPassive portPassive)
        {
            throw new NotImplementedException();
        }

        IPortActive IFrameWork.GetPortActive(int itemID, int portNumber)
        {
            throw new NotImplementedException();
        }

        IPortPassive IFrameWork.GetPortPassive(int itemID, int portNumber)
        {
            throw new NotImplementedException();
        }

        bool IFrameWork.RemovePort(int itemID, int portNumber)
        {
            throw new NotImplementedException();
        }

        bool IFrameWork.ModifyPortActive(int itemID, IPortActive portActive)
        {
            throw new NotImplementedException();
        }

        bool IFrameWork.AddConnection(IConnection connection)
        {
            throw new NotImplementedException();
        }

        IConnection IFrameWork.GetConnection(int connectionID)
        {
            throw new NotImplementedException();
        }

        bool IFrameWork.ModifyConnection(IConnection connection)
        {
            throw new NotImplementedException();
        }

        bool IFrameWork.AddLocation(ILocation location)
        {
            throw new NotImplementedException();
        }

        ILocation IFrameWork.GetLocation(int itemID)
        {
            throw new NotImplementedException();
        }

        bool IFrameWork.ModifyLocation(ILocation location)
        {
            throw new NotImplementedException();
        }

        bool IFrameWork.GetItemActive()
        {
            throw new NotImplementedException();
        }

        IItemPassive IFrameWork.GetItemPassive()
        {
            throw new NotImplementedException();
        }
    }
}
