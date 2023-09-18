using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    public class ProgrammaEventi
    {
        private string titolo;
        private List<Evento> eventi;

        public ProgrammaEventi(string titolo)
        {
            this.titolo = titolo;
            eventi = new List<Evento>();
        }
    }
}
