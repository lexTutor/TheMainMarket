using HotChocolate;
using System;
using System.Collections.Generic;
using System.Text;
using TheMainMarket.Commons.CustomException;

namespace TheMainMarket.Commons.ErrorFilters
{
    public class IdentityErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            if (error.Exception is IdentityException ex)
                return error.WithMessage($"The following errors occured: {ex}");

            return error;
        }
    }
}
