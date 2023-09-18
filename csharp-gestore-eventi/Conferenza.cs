using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    public class Conferenza : Evento
    {
        private string relatore;
        private double prezzo;
        public Conferenza(string relatore, double prezzo,string titolo, string data, int capienzaMassima) : base(titolo, data, capienzaMassima)
        {
            SetRelatore(relatore);
            SetPrezzo(prezzo);
        }
        
        //SETTERS 
        public void SetPrezzo(double prezzo)
        {
            if(prezzo < 0)
            {
                throw new Exception("Il prezzo non puo essere negativo");
            }

            this.prezzo = prezzo;
        }

        public void SetRelatore(string relatore)
        {
            if(string.IsNullOrEmpty(relatore))
            {
                throw new Exception("Il relatore della conferenza non puo essere vuoto");
            }
            this.relatore = relatore;
        }

        //GETTERS
        public string GetRelatore()
        {
            return this.relatore;
        }

        public double GetPrezzo()
        {
            return prezzo;
        }

        //METODI
        public string DataFormattata()
        {
            return this.GetData().ToString("dd/MM/yyyy");
        }
        public string PrezzoFormattato()
        {
            return this.GetPrezzo().ToString("0.00");
        }

        public override string ToString()
        {
            return $"Data: {DataFormattata()} - Titolo: {this.GetTitolo()} - Relatore: {this.GetRelatore()} - Prezzo:{PrezzoFormattato()} euro";
        }
    }
}
