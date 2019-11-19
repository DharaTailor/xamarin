using System;
using System.Collections.Generic;
using System.Text;

namespace WebService
{
    public class ResponseModel
    {
        public string Body { get; set; }
        public string Message { get; set; }
        public RemoteResult Result { get; set; }
    }
}
