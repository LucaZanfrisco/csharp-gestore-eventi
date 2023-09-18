using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    public class ProgrammaEventi
    {
        private string titolo;
        public List<Evento> eventi;

        public ProgrammaEventi(string titolo)
        {
            this.titolo = titolo;
            eventi = new List<Evento>();
        }

        public void AggiungiEvento(Evento evento)
        {
            eventi.Add(evento);
        }

        public List<Evento> ListaEventiData(DateTime data)
        {
            List<Evento> eventiCercati = new List<Evento>();
            foreach (Evento evento in eventi)
            {
                if(evento.GetData() == data)
                {
                    eventiCercati.Add(evento);
                }
            }
            return eventiCercati;
        }

        public static void StampaListaEventi(List<Evento> eventi)
        {
            foreach(Evento evento in eventi)
            {
                Console.WriteLine($"{evento.GetData().ToString()} - {evento.GetTitolo()} - {evento.GetPostiPrenotati()} - {evento.GetCapienzaMassima()}");
            }
        }

        public int NumeroEventiInProgramma()
        {
            return this.eventi.Count;
        }

        public void SvuotaListaEventi()
        {
            eventi.Clear();
        }

        public void StampaProgramma()
        {
            Console.WriteLine($"Nome programma evento: {this.titolo}");
            foreach(Evento evento in eventi)
            {
                Console.WriteLine($"{evento.ToString()} ");
            }
        }
    }
}
