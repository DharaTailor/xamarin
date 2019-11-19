using System;
using System.Collections.Generic;
using System.Text;

namespace WebService
{
    public class RequestModel
    {
        public string Url { get; set; }
        public string Key { get; set; }
        public string Body { get; set; }
        public ServiceMethod Method { get; set; }
        public string Header { get; set; }
    }
}
