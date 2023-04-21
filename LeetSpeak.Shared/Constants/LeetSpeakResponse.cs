using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetSpeak.Shared.Models
{
    public class LeetSpeakResponse
    {
        public object? ResponseMessage { get; set; }
        public bool HasError { get; set; }
    }
}
