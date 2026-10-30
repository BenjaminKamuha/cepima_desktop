using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cepima.MesForms.Personnel
{
    class SalaireItem
    {
        public int Id { get; set; }
        public string Texte { get; set; }

        public override string ToString()
        {
            return Texte;
        }
    }
}
