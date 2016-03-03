using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_ac73.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
