using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Models;

namespace BusinessLayer.Interfaces
{
    interface IValidationAttribute<T>
    {
        ValidationResult Validate(T input);
    }
}
