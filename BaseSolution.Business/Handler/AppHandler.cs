using BaseSolution.Abstraction.Handlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseSolution.Business.Handler
{
    public class AppHandler : IHandler
    {
        public T Run<T>(Func<T> func)
        {
			try
			{
				return func.Invoke();
			}
			catch (Exception)
			{
				return default(T);
			}
        }
    }
}
