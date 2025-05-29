using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutprojekt_Viggo
{
    internal class Kundvagn(string serienummer, int mangd)
    {
        
        
            public string Serienummer { set; get; } = serienummer;
            public int Mangd { set; get; } = mangd;
        
    }
}
