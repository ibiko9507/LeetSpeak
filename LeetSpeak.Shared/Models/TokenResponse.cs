﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetSpeak.Shared.Models
{
    public class TokenResponse
    {
        public string AccessToken { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
