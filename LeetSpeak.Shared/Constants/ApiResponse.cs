using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetSpeak.Shared.Constants
{
    public class ApiResponse
    {
        public Content Contents { get; set; }

        public class Content
        {
            public string translated { get; set; }
            public string text { get; set; }
		}
    }
}
