using System;
using System.Collections.Generic;
using System.Text;

namespace CareControl_Service.Contract
{
    public class LoginResponse
    {
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }

        public int StatusCode { get; set; }
        public string Token { get; set; }

    }
}
