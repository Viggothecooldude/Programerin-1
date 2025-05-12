using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutprojekt_Viggo
{
    class Vara(int serienummer, string namn, int pris)
    {
        public int Serienummer { get; } = serienummer;
        public string Namn { get; } = namn;
        public int Pris { set; get; } = pris;
        
    }
}
