using System;
using System.Collections.Generic;
using System.Text;

namespace TheMainMarket.Commons.CustomException
{
    public class ModelExceptions: Exception
    {
        public string DefaultError { get; set; }
    }
}
