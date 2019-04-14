using Common;
using Common.Interfaces;
using Common.Support;
using Common.Support._interfaces;
using DataLayer.Interfaces;
using System;
using System.Collections.Generic;

namespace Common
{
    public class FrameWork : IFrameWork
    {
        private IDataService dataService;
        private ILogService logService;
        private IErrorService errorService;
        private IRegisterActive registerActive;
        private IRegisterPortActive registerPortActive;
        private IUIFactory uiFactory;
        private IRegisterConnection registerConnection;
        private IRegisterSymbol registerSymbol;
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
            registerPortActive = new RegisterPortActive(logService, errorService);
            registerConnection = new RegisterConnection(logService, errorService);
            registerSymbol = new RegisterSymbol(logService, errorService);
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
                ok = registerActive.Add(item);
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

            IList<IPortActive> portList = new List<IPortActive>();

            portList = dataService.GetPortActive();

            foreach (var item in portList)
            {
                registerPortActive.Add(item);
            }

            IList<IConnection> connectionList = new List<IConnection>();

            connectionList = dataService.GetConnection();

            foreach (var item in connectionList)
            {
                registerConnection.Add(item);
            }

            IList<ISymbol> symbolList = new List<ISymbol>();

            symbolList = dataService.GetSymbol();

            foreach (var item in symbolList)
            {
                item.Load();
                registerSymbol.Add(item);
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
            // TODO: ha frissíti az activeItem port listáját, akkor kell frissíteni az adatbázisban az item adatait
            bool ok = false;

            string message;

            IError error = dataService.InsertPortActive(portActive);

            if (!error.IsError)
            {
                message = "Aktív port elmentve " + portActive.PortID;
                ok = registerPortActive.Add(portActive);
                if (ok)
                {
                error = registerActive[itemID].AddPort(portActive);
                message += error.Message;
                }
                if (!error.IsError)
                {
                error = dataService.UpdateItemActive(registerActive[itemID]);
                message += error.Message;
                }
            }
            else
            {
                message = error.Message;
            }

            logService.Create(message);

            return ok;
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
            bool ok = false;

            string message;

            IError error = dataService.InsertConnection(connection);

            if (!error.IsError)
            {
                message = "Kapcsolat elmentve " + connection.Name;
                ok = registerConnection.Add(connection);
                if (ok)
                {
                registerActive[connection.SourceItemId].AddConnection(connection);
                message += error.Message;
                registerActive[connection.DestinationItemId].AddConnection(connection);
                message += error.Message;
                }
                if (!error.IsError)
                {
                    error = dataService.UpdateItemActive(registerActive[connection.SourceItemId]);
                    message += error.Message;
                    error = dataService.UpdateItemActive(registerActive[connection.DestinationItemId]);
                    message += error.Message;
                }
            }
            else
            {
                message = error.Message;
            }

            logService.Create(message);

            return ok;
        }

        IConnection IFrameWork.GetConnection(int connectionID)
        {
            IConnection connection = registerConnection[connectionID];
            return connection;
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

        bool IFrameWork.AddSymbol(ISymbol symbol)
        {
            bool ok = false;

            string message;

            IError error = dataService.InsertSymbol(symbol);

            if (!error.IsError)
            {
                message = "Ábra elmentve " + symbol.Name;
                ok = registerSymbol.Add(symbol);
            }
            else
            {
                message = error.Message;
            }

            logService.Create(message);

            return ok;
        }

        ISymbol IFrameWork.GetSymbol(int id)
        {
            ISymbol symbol = registerSymbol[id];

            return symbol;
        }

        bool IFrameWork.ModifySymbol(ISymbol symbol)
        {
            throw new NotImplementedException();
        }

        bool IFrameWork.RemoveSymbol(ISymbol symbol)
        {
            throw new NotImplementedException();
        }
    }
}
