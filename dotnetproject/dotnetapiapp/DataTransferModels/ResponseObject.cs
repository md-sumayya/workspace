using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetapiapp.DataTransferModels
{
    public class ResponseObject
    {
        public ResponseObject(bool isSuccess,object data,string message = ""){
            isSuccess = isSuccess;
            data = data;
            message = message;
        }
        public bool isSuccess { get; set; }
        public string message { get; set; }
        public object data { get; set; }
    }
}