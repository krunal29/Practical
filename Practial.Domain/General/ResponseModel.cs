using System;
using System.Collections.Generic;
using System.Text;

namespace Practial.Domain
{
    public class ResponseModel
    {
        public object Data { get; set; }

        public string Message { get; set; }

        public bool Status { get; set; }
    }
}
