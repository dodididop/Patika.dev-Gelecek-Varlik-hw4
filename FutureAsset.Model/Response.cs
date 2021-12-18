using System;
namespace FutureAsset.Model
{
    public class Response<T>
    {
        public Response()
        { 
        }
        public Response(T data)
        {
            IsSuccess = true;
            Message = string.Empty;
            Errors = null;
            Data = data;
        }
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public string[] Errors { get; set; }
        public string Message { get; set; }
    }
}
