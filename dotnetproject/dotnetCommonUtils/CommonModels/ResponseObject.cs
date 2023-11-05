using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace dotnetCommonUtils.CommonModels
{
    public class ResponseObject<T>
    {
        public ResponseObject(){

        }
        public ResponseObject(bool IsSuccess,string ErrorMessage,T data){
            IsSuccess = IsSuccess;
            ErrorMessage = ErrorMessage;
            data = data;
        }
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; } ="";
        public T data { get; set; }
    }
}