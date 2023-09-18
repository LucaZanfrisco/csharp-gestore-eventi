// See https://aka.ms/new-console-template for more information

using csharp_gestore_eventi;

Console.WriteLine("Benvenuto nel programma per la gestione di Eventi");

Console.Write("\nInserisci il nome del tuo programma Eventi: ");
string titoloProgramma = Console.ReadLine();

while(string.IsNullOrEmpty(titoloProgramma))
{
    Console.Write("Inserire un titolo del programma: ");
    titoloProgramma = Console.ReadLine();
}
ProgrammaEventi programma = new ProgrammaEventi(titoloProgramma);

bool scelta = false;
while(!scelta)
{
    Console.Write(@"
Azioni:
1 - Aggiungere un evento ad un programma
2 - Stampare la lista degli eventi
3 - Cercare gli eventi per data
4 - Mostare il numero di eventi in programma
5 - Aggiungere una conferenza
6 - Svuota lista eventi
7 - Esci
Scrivere un numero per svolgere una azione: ");
    int azioneScelta = 0;
    try
    {
        azioneScelta = int.Parse(Console.ReadLine());
    }catch(Exception ex) 
    {
        Console.WriteLine(ex.Message);
    }
    

    switch(azioneScelta) 
    {
        case 1:

            int numeroEventi;
            do
            {
                Console.Write("\nIndica il numero di eventi da inserire: ");
                numeroEventi = int.Parse(Console.ReadLine());

            } while(numeroEventi <= 0);
            int i = 0;
            while(i < numeroEventi)
            {
                try
                {
                    Console.WriteLine($"\n{programma.eventi.Count + 1}° Evento");
                    Console.Write("Inserisci il nome del'evento: ");
                    string titoloEvento = Console.ReadLine();

                    Console.Write("Inserisci data dell'evento (gg/mm/yyyy): ");
                    string dataEvento = Console.ReadLine();

                    Console.Write("Inserisci il numero di posti totali: ");
                    int capienzaMassima = int.Parse(Console.ReadLine());

                    Evento evento = new Evento(titoloEvento, dataEvento, capienzaMassima);

                    bool sceltaEvento = false;
                    while(!sceltaEvento)
                    {
                        Console.Write($@"
Per l'evento {evento.GetTitolo()} si vogliono compiere le seguenti azioni:
1 - Prenotare posti
2 - Disdire posti
3 - Informazioni sui posti
4 - Esci
Inserire il numero per svolgere una delle seguenti azioni: ");
                    int sceltaAzionePerEvento = int.Parse(Console.ReadLine());

                        switch(sceltaAzionePerEvento)
                        {
                            case 1:
                                Console.Write("\nQuanti posti si desidera prenotare: ");
                                int postiDaPrenotare = int.Parse(Console.ReadLine());
                                evento.PostiPrenotati(postiDaPrenotare);
                                break;
                            case 2:
                                Console.Write("\nQuanti posti si desidera disdire: ");
                                int postiDisdetti = int.Parse(Console.ReadLine());
                                evento.DisdiciPosti(postiDisdetti);
                                break;
                            case 3:
                                Console.WriteLine($"\nNumero di posti prenotati = {evento.GetPostiPrenotati()}");
                                Console.WriteLine($"Numero di posti disponibili = {evento.GetCapienzaMassima() - evento.GetPostiPrenotati()}");
                                break;
                            case 4:
                                sceltaEvento = true;
                                break;
                            default:
                                Console.WriteLine("\nIl numero selezionato non corrisponde a nessuna azione");
                                break;
                        }
                    }
                   

                    programma.eventi.Add(evento);
                    i++;
                }
                catch(Exception ex)
                {
                    Console.WriteLine("IMPOSSIBILE SALVARE");
                    Console.WriteLine($"ERRORE: {ex.Message.ToUpper()}");
                }
            }
            break; 
        case 2:
            if(programma.eventi.Count > 0)
            {
                programma.StampaProgramma(programma.eventi);
            }
            else
            {
                Console.WriteLine("\nNessun evento per questo programma");
            }
            
            break;
        case 3:
            Console.Write("\nInserisci una data per sapere che eventi ci saranno (gg/mm/yyyy): ");
            DateTime cercaData = DateTime.Parse(Console.ReadLine());

            List<Evento> eventoPerData = programma.ListaEventiData(cercaData);

            if(eventoPerData.Count > 0)
            {
                programma.StampaProgramma(eventoPerData);
            }
            else
            {
                Console.WriteLine($"\nNon ci sono eventi in programma per la data {cercaData}");
            }

            break;
        case 4:
            Console.Write($"\nIl numero di eventi presenti in programma è: {programma.NumeroEventiInProgramma()}");
            break;
        case 5:
            try
            {
                Console.Write("\nInserisci il nome della conferenza: ");
                string nomeConferenza = Console.ReadLine();

                Console.Write("Inserisci data della conferenza (gg/mm/yyyy): ");
                string dataConferenza = Console.ReadLine();

                Console.Write("Inserisci il numero di posti per la conferenza: ");
                int numeroPostiConferenza = int.Parse(Console.ReadLine());

                Console.Write("Inserisci il relatore della conferenza: ");
                string relatoreConferenza = Console.ReadLine();

                Console.Write("Inserisci il prezzo del biglietto della conferenza: ");
                double prezzoBiglietto = double.Parse(Console.ReadLine());

                Conferenza conferenza = new Conferenza(relatoreConferenza, prezzoBiglietto, nomeConferenza, dataConferenza, numeroPostiConferenza);

                programma.eventi.Add(conferenza);

            }catch(Exception ex)
            {
                Console.WriteLine("IMPOSSIBILE SALVARE");
                Console.WriteLine($"ERRORE: {ex.Message.ToUpper()}");
            }
            
            break;
        case 6:
            programma.SvuotaListaEventi();
            break;
        case 7:
            scelta = true;
            break;
        default:
            Console.WriteLine("\nIl numero selezionato non copie nessuna azione");
            break;
    }

}



