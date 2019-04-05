using Common;
using Common.Interfaces;
using DataLayer.Interfaces;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Common.Models;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using BusinessLayer;

namespace DataLayer
{
    public class DataService : IDataService
    {
        private bool isMySQL;
        private LiteRepository repo;
        private IErrorService errorService;

        public DataService(bool isMySQL, LiteRepository repo, IErrorService errorService)
        {
            this.isMySQL = isMySQL;
            this.repo = repo;
            this.errorService = errorService;
        }

        IError IDataService.InsertItemActive(IItemActive item)
        {
            IError error = ErrorInit();

            try
            {
                repo.Insert((ItemActive)item);
                return error;
            }
            catch (Exception ex)
            {
                error = Helpers.ErrorMessage(ErrorType.NoUniqueID,
                    ex.Message);
                errorService.Write(error);
                return error;
            }
        }

        IList<IItemActive> IDataService.GetItemActive()
        {
            IList<IItemActive> result = new List<IItemActive>();

            var result2 = repo.Query<ItemActive>().ToList();
            foreach (var item in result2)
            {
                result.Add(item);
            }

            return result;
        }

        /// <summary>
        /// Gets a user from database by email, returns null if not found
        /// </summary>
        public User GetUser(string email)
        {
            return repo.Query<User>().ToList().SingleOrDefault(u => u.Email == email);
        }

        /// <summary>
        /// Gets a user from the database based on the user's id. Returns null if no user is found.
        /// </summary>
        /// <param name="id">Id of the user</param>
        /// <returns>User</returns>
        public User GetUser(int id)
        {
            return repo.Query<User>().ToList().SingleOrDefault(i => i.Id == id);
        }

        /// <summary>
        /// Inserts a user to the database. Returns true if successful
        /// </summary>
        public bool InsertUser(User user)
        {
            IError error = ErrorInit();

            try
            {
                repo.Insert(user);
                return true;
            }
            catch (Exception ex)
            {
                error = Helpers.ErrorMessage(ErrorType.NoUniqueID,
                    ex.Message);
                errorService.Write(error);
                return false;
            }
        }

        /// <summary>
        /// Updates a user in the database. Returns false if not found in the collection.
        /// </summary>
        public bool UpdateUser(User user)
        {
            return repo.Update(user);
        }

        /// <summary>
        /// Deletes a user from the database based on ID.
        /// </summary>
        public bool DeleteUser(User user)
        {
            return repo.Delete<User>(u => u.Id == user.Id) > 0;
        }


        IItemActive IDataService.GetItemActive(int id)
        {
            return repo.Query<ItemActive>().Where(x => x.Id == id).SingleOrDefault();
        }

        IError IDataService.DeleteConnection(IConnection connection)
        {
            throw new NotImplementedException();
        }

        IError IDataService.DeleteConnectorWall(IConnectorWall connector)
        {
            throw new NotImplementedException();
        }

        IError IDataService.DeleteItemActive(IItemActive item)
        {
            throw new NotImplementedException();
        }

        IError IDataService.DeleteItemPassive(IItemPassive item)
        {
            throw new NotImplementedException();
        }

        IError IDataService.DeleteLocation(ILocation location)
        {
            throw new NotImplementedException();
        }

        IError IDataService.DeletePortActive(IPortActive port)
        {
            throw new NotImplementedException();
        }

        IError IDataService.DeletePortPassive(IPortPassive port)
        {
            throw new NotImplementedException();
        }

        IError IDataService.DeleteSymbol(ISymbol symbol)
        {
            throw new NotImplementedException();
        }

        IList<IConnection> IDataService.GetConnection()
        {
            throw new NotImplementedException();
        }

        IConnection IDataService.GetConnection(int id)
        {
            throw new NotImplementedException();
        }

        IList<IConnectorWall> IDataService.GetConnectorWall()
        {
            throw new NotImplementedException();
        }

        IConnectorWall IDataService.GetConnectorWall(int id)
        {
            throw new NotImplementedException();
        }

       

        IList<IItemPassive> IDataService.GetItemPassive()
        {
            throw new NotImplementedException();
        }

        IItemPassive IDataService.GetItemPassive(int id)
        {
            throw new NotImplementedException();
        }

        IList<ILocation> IDataService.GetLocation()
        {
            throw new NotImplementedException();
        }

        ILocation IDataService.GetLocation(int id)
        {
            throw new NotImplementedException();
        }

        IList<IPortActive> IDataService.GetPortActive()
        {
            throw new NotImplementedException();
        }

        IPortActive IDataService.GetPortActive(int id)
        {
            throw new NotImplementedException();
        }

        IList<IPortPassive> IDataService.GetPortPassive()
        {
            throw new NotImplementedException();
        }

        IPortPassive IDataService.GetPortPassive(int id)
        {
            throw new NotImplementedException();
        }

        IList<ISymbol> IDataService.GetSymbol()
        {
            throw new NotImplementedException();
        }

        ISymbol IDataService.GetSymbol(int id)
        {
            throw new NotImplementedException();
        }

        IError IDataService.InsertConnection(IConnection connection)
        {
            throw new NotImplementedException();
        }

        IError IDataService.InsertConnectorWall(IConnectorWall connector)
        {
            throw new NotImplementedException();
        }

        

        private static IError ErrorInit()
        {
            return Helpers.ErrorMessage(ErrorType.NoError);
        }

        IError IDataService.InsertItemPassive(IItemPassive item)
        {
            throw new NotImplementedException();
        }

        IError IDataService.InsertLocation(ILocation location)
        {
            throw new NotImplementedException();
        }

        IError IDataService.InsertPortActive(IPortActive port)
        {
            throw new NotImplementedException();
        }

        IError IDataService.InsertPortPassive(IPortPassive port)
        {
            throw new NotImplementedException();
        }

        IError IDataService.InsertSymbol(ISymbol symbol)
        {
            throw new NotImplementedException();
        }

        IError IDataService.UpdateConnection(IConnection connection)
        {
            throw new NotImplementedException();
        }

        IError IDataService.UpdateConnectorWall(IConnectorWall connector)
        {
            throw new NotImplementedException();
        }

        IError IDataService.UpdateItemActive(IItemActive item)
        {
            throw new NotImplementedException();
        }

        IError IDataService.UpdateItemPassive(IItemPassive item)
        {
            throw new NotImplementedException();
        }

        IError IDataService.UpdateLocation(ILocation location)
        {
            throw new NotImplementedException();
        }

        IError IDataService.UpdatePortActive(IPortActive port)
        {
            throw new NotImplementedException();
        }

        IError IDataService.UpdatePortPassive(IPortPassive port)
        {
            throw new NotImplementedException();
        }

        IError IDataService.UpdateSymbol(ISymbol symbol)
        {
            throw new NotImplementedException();
        }
    }
}
