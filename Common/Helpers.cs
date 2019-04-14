using Common.Interfaces;
using Common.Models;
using System.Collections.Generic;

namespace Common
{
    public static class Helpers
    {
        public static IError ErrorMessage(ErrorType errorType, string errorMessage = "")
        {
            IError error = new Error(errorType, errorMessage);
            return error;
        }

        public static IList<string> GetSymbolNames()
        {
            IList<string> symbolNameList = new List<string>
            {
                "switch","pc","server","wirelessrouter",
                "linevertical","linehorizontal",
                "accesspoint","bridge","hub","multilayerswitch",
                "opticalcrossconnect","opticalrouter"
            };
            return symbolNameList;
        }

        public enum ErrorType
        {
            NoError = 0,
            DatabaseError,
            InputError,
            NoUniqueID,
            NoItem
        }

        public enum ConnectorType
        {
            Single,
            Double,
            Rated
        }
    }
}
