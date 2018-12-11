using System;
using System.Collections.Specialized;

namespace WebServerProj
{
    public abstract class AbsHttpHeaderEvaluator
    {
        public abstract string HeaderName { get;  }
        public abstract string ErrorCode { get;  }

        public bool Evaluate(NameValueCollection headers)
        {
            bool noContains = true;
            foreach (var header in headers)
            {
                if (header.ToString() == "Accept")
                {
                    return noContains;
                }
            }
            throw new Exception($"{ErrorCode} - {HeaderName}");
        } 
    }
}