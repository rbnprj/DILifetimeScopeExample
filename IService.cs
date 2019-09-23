using System;
using System.Collections.Generic;
using System.Text;

namespace DILifetimeScopesExample
{


    public interface ISingletonServices
    {
        void Info();
    }
    public interface IScopedServices { void Info(); }
    public interface ITransientServices { void Info(); }
}
