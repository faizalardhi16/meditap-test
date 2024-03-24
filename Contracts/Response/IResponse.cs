using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meditaps.Contracts.Response
{
    public class IResponse<T>
    {
        public int StatusCode {get; set;}
        public string Message {get; set;}
        public T? Data {get; set;}
    }
}