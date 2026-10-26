using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialInvetigationApp.Common.Exceptions
{
    public class NotFoundExceptions : Exception
    {
        public NotFoundExceptions(string entityName, object key)
        : base($"{entityName} with id '{key}' was not found.")
        {
            
        }
    }
}
