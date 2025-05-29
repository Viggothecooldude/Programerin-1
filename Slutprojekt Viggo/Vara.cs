using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutprojekt_Viggo
{
    class Vara(string serienummer, string namn, int pris) //, int mangd)
    {
        public string Serienummer { get; } = serienummer;
        public string Namn { get; } = namn;
        public int Pris { set; get; } = pris;
      //  public int Mangd { set; get;} = mangd;
        
    }
    
}
