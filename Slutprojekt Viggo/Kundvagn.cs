using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutprojekt_Viggo
{
    internal class Kundvagn(string serienummer, int mangd)//klass för att spara specifika varor användaren väljer
    {
            public string Serienummer { get; } = serienummer;
            public int Mangd { set; get; } = mangd;
    }
}
