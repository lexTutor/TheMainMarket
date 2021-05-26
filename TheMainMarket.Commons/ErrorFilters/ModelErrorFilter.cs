using HotChocolate;
using System;
using System.Collections.Generic;
using System.Text;
using TheMainMarket.Commons.CustomException;

namespace TheMainMarket.Commons.ErrorFilters
{
    public class ModelErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            if (error.Exception is ModelExceptions ex)
                return error.WithMessage(ex.DefaultError);

            return error;
        }
    }
}
