﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Pokloni.ba.Model.Requests
{
    public class KorisniciInsertRequest
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
    }
}
