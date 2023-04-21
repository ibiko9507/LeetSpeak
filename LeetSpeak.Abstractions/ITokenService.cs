using LeetSpeak.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetSpeak.Abstractions
{
    public interface ITokenService
    {
        TokenResponse CreateAccessToken(int day);
    }
}
