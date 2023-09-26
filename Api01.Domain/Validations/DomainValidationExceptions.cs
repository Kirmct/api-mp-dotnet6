using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api01.Domain.Validations;

public class DomainValidationExceptions : Exception
{
    public DomainValidationExceptions(string error) : base(error)
    {      
    }

    public static void When(bool hasError, string message)
    {
        if (hasError)
        {
            throw new DomainValidationExceptions(message);
        }
    }

}
