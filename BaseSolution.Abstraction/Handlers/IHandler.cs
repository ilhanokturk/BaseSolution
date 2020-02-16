using System;
using System.Collections.Generic;
using System.Text;

namespace BaseSolution.Abstraction.Handlers
{
    public interface IHandler
    {
        T Run<T>(Func<T> func);
    }
}
