using System;

namespace VWB.App.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string msg, int code, Exception inner)
            : base(msg, inner)
        {
            Code = code;
        }

        public int Code { get; }
    }
}
