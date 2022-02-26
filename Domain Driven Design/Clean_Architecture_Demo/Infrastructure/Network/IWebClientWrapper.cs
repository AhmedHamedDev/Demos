using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Network
{
    public interface IWebClientWrapper
    {
        void Post(string address, string json);
    }
}
