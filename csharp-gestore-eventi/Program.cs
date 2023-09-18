// See https://aka.ms/new-console-template for more information

using csharp_gestore_eventi;

//Console.Write("Inserire il nome dell'evento: ");
//string titolo = Console.ReadLine();

//Console.Write("Inserire la data dell'evento: ");
//string data = Console.ReadLine();

//Console.Write("Inserire il numero di posti totali: ");
//int capienzaMassima = int.Parse(Console.ReadLine());

//Evento evento = new Evento(titolo, data, capienzaMassima);

//Console.Write("\nQuanti posti si desidera prenotare: ");
//int postiDaPrenotare = int.Parse(Console.ReadLine());

//evento.PostiPrenotati(postiDaPrenotare);

//bool controlloDisdetta = false;

//while(!controlloDisdetta)
//{

//    Console.WriteLine($"Numero di posti prenotati = {evento.GetPostiPrenotati()}");
//    Console.WriteLine($"Numero di posti disponibili = {evento.GetCapienzaMassima() - evento.GetPostiPrenotati()}");

//    Console.WriteLine();

//    Console.Write("Desidera disdire dei posti? ");
//    string disdire = Console.ReadLine();

//    if(disdire.ToLower() == "no")
//    {
//        break;
//    }

//    Console.Write("Quanti posti si desidera disdire: ");
//    int postiDisdetti = int.Parse(Console.ReadLine());
//    evento.DisdiciPosti(postiDisdetti);
//}

//Console.WriteLine($"Numero di posti prenotati = {evento.GetPostiPrenotati()}");
//Console.WriteLine($"Numero di posti disponibili = {evento.GetCapienzaMassima() - evento.GetPostiPrenotati()}");

Console.Write("Inserisci il nome del tuo programma Eventi: ");
string titoloProgramma = Console.ReadLine();

Console.Write("Indica il numero di eventi da inserire: ");
int numeroEventi = int.Parse(Console.ReadLine());

ProgrammaEventi programma = new ProgrammaEventi(titoloProgramma);

while(programma.eventi.Count < numeroEventi)
{
    try
    {
        Console.WriteLine();
        Console.WriteLine($"{programma.eventi.Count + 1}° Evento");
        Console.Write("Inserisci il nome del'evento: ");
        string titoloEvento = Console.ReadLine();

        Console.Write("Inserisci data dell'evento (gg/mm/yyyy): ");
        string dataEvento = Console.ReadLine();

        Console.Write("Inserisci il numero di posti totali: ");
        int capienzaMassima = int.Parse(Console.ReadLine());

        Evento evento = new Evento(titoloEvento, dataEvento, capienzaMassima);
        programma.eventi.Add(evento);
    }
    catch(Exception ex)
    {
        Console.WriteLine(ex.Message.ToUpper());
    }
}

Console.Write($"Il numero di eventi presenti in programma è: {programma.NumeroEventiInProgramma()}");
Console.WriteLine();
programma.StampaProgramma(programma.eventi);

Console.WriteLine();

Console.Write("Inserisci una data per sapere che eventi ci saranno (gg/mm/yyyy): ");
DateTime cercaData = DateTime.Parse(Console.ReadLine());

List<Evento> eventoPerData = programma.ListaEventiData(cercaData);

programma.StampaProgramma(eventoPerData);

programma.SvuotaListaEventi();

