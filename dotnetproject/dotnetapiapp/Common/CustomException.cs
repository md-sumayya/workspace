using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetapiapp.Common
{
    [Serializable]
    public class CustomException :Exception
    {
        public int ErrorCode{get;set;}
        public CustomException(){}
        public CustomException(string message,int ErrorCode = 0):base(message)
        {
            ErrorCode = ErrorCode;
        }
    }
}