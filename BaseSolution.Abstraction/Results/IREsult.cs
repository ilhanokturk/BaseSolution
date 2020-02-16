using System;
using System.Collections.Generic;
using System.Text;

namespace BaseSolution.Abstraction.Results
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
