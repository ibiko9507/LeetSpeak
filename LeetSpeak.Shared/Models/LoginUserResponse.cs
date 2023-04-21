using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetSpeak.Shared.Models
{
    public class LoginUserResponse
    {
        public User User { get; set; }
        public bool IsLoggedIn { get; set; }
        public TokenResponse Token { get; set; }
    }
}
