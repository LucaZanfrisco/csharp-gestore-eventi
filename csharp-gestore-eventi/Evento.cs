﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    public class Evento
    {
        private string titolo;
        private DateTime data;
        private int capienzaMassima;
        private int postiPrenotati;

        // COSTRUTTORE
        public Evento(string titolo, string data, int capienzaMassima)
        {
            SetTitolo(titolo);
            SetDate(data);
            SetCapienzaMassima(capienzaMassima);
            this.postiPrenotati = 0;
        }

        // SETTERS
        public void SetTitolo(string titolo)
        {
            if(string.IsNullOrEmpty(titolo))
            {
                throw new Exception("Il titolo dell'evento non puo essere vuoto");
                return;
            }
            this.titolo = titolo;
        }
        public void SetDate(string data)
        {
            DateTime dataInserita = DateTime.Parse(data);
            if(dataInserita < DateTime.Today)
            {
                throw new Exception("La data inserita è minore della data odierna");
                return;
            }

            this.data = dataInserita;
        }
        public void SetCapienzaMassima(int capienza)
        {
            if(capienza < 0)
            {
                throw new Exception("La capienza di un evento non puo essere minore di 0");
                return;
            }
            this.capienzaMassima = capienza;
        }

        // GETTERS
        public string GetTitolo()
        {
            return this.titolo;
        }
        public DateTime GetData()
        {
            return this.data;
        }
        public int GetCapienzaMassima()
        {
            return this.capienzaMassima;
        }
        public int GetPostiPrenotati()
        {
            return this.postiPrenotati;
        }

        // METODI
        public void PostiPrenotati(int posti)
        {
            if(posti < 0)
            {
                throw new Exception("Non è possibile prenotare un numero di posti negativo");
                return;
            }
            if(DateTime.Today > this.data)
            {
                throw new Exception("L'evento è gia passato, non si possono prentore posti");
                return;
            }
            if(this.postiPrenotati + posti >= this.capienzaMassima)
            {
                throw new Exception("Il numero di posti disponibili non sufficienti");
                return;
            }
            this.postiPrenotati += posti;
        }

        public void DisdiciPosti(int posti)
        {
            if(posti < 0)
            {
                throw new Exception("Non è possibile disdire un numero di posti negativo");
                return;
            }
            if(DateTime.Today > this.data)
            {
                throw new Exception("L'evento è gia passato, non si possono disdire posti");
                return;
            }
            if(this.postiPrenotati == 0 || this.postiPrenotati - posti <= 0)
            {
                throw new Exception("Numero di posti disdetti maggiore dei posti prenotati");
                return;
            }
            this.postiPrenotati -= posti;
        }

        public override string ToString()
        {
            return $"{this.data.ToString("dd/MM/yyyy")} - {this.titolo}";
        }
    }
}