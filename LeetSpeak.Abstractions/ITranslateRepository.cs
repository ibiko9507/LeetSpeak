using LeetSpeak.Shared.Constants;
using LeetSpeak.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetSpeak.Abstractions
{
    public interface ITranslateRepository
    {
        Task AddTranslation(Translation translation);
        void Dispose();
    }
}
