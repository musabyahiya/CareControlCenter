﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CareControl_Service.Contract
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
