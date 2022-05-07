using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Managment
{
    public static class HeadOfficeInstance
    {
        private const long HeadofficeId = 1;
        public static HeadOffice Instance { get; private set; }

        public static void Init()
        {
        }

    }
}
