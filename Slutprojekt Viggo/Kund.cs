using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutprojekt_Viggo
{
    internal class Kund(bool medlem, string namn, string lösenord, double saldo)
    {
        public bool Medlem { get; set; } = medlem;
        public string Namn { get;  } = namn;
        public string Lösenord { get;  } = lösenord;
        public double Saldo { get; set; } = saldo;
    }
}
