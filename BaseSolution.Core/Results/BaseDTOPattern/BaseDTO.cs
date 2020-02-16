using System;
using System.Collections.Generic;
using System.Text;

namespace BaseSolution.Core.Results.BaseDTOPattern
{
    public class BaseDTO<T>:IDisposable
    {
        public Status Status { get; set; }
        public T Data { get; set; }
        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }

        public void Dispose()
        {
            SuccessMessage = string.Empty;
            ErrorMessage = string.Empty;
            if (Data != null)
                if (Data is IDisposable)
                    ((IDisposable)Data).Dispose();
        }
    }
}
