using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;

namespace BusinessLayer
{
    public class RegisterSymbol : IRegisterSymbol
    {
        private ILogService logService;
        private IErrorService errorService;
        private IList<ISymbol> symbolList;

        public RegisterSymbol(ILogService logService, IErrorService errorService)
        {
            this.logService = logService;
            this.errorService = errorService;
            symbolList = new List<ISymbol>();
        }

        ISymbol IRegisterSymbol.this[int ID]
        {
            get
            {
                if (symbolList.Count > 0)
                {
                    return symbolList.Where(x => x.Id == ID).FirstOrDefault();
                }
                return null;
            }
        }

        bool IRegisterSymbol.Add(ISymbol symbol)
        {
            // TODO hibakezelés, ellenőrizni, megfelelő értékeket tartalmaz
            // a ItemActive

            bool ok = true;

            symbolList.Add(symbol);

            return ok;
        }

        bool IRegisterSymbol.Remove(ISymbol symbol)
        {
            bool ok = false;
            // TODO: van e connection
            if (symbolList.Remove(symbol))
            {
                ok = true;

                return ok;
            }
            else
            {
                IError error = Helpers.ErrorMessage(ErrorType.NoUniqueID,
                    "Nem létezik ilyen ábra");

                errorService.Write(error);

                return ok;
            }
        }

        bool IRegisterSymbol.Remove(int id)
        {
            bool ok = false;
            // TODO: van e connection
            int index = GetIndex(id);
            if (index >= 0)
            {
                symbolList.RemoveAt(index);

                ok = true;

                return ok;
            }
            else
            {
                IError error = Helpers.ErrorMessage(ErrorType.NoUniqueID,
                    "Nem létezik ilyen ábra");

                errorService.Write(error);

                return ok;
            }
        }
        private int GetIndex(int ID)
        {
            return symbolList.IndexOf(symbolList.Where(x => x.Id == ID).FirstOrDefault());
        }
    }
}
