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

Console.WriteLine();

Console.Write("Indica il numero di eventi da inserire: ");
int numeroEventi = int.Parse(Console.ReadLine());

ProgrammaEventi programma = new ProgrammaEventi(titoloProgramma);

while(programma.eventi.Count < numeroEventi)
{
    Console.Write("Inserisci il nome del'evento: ");
    string titoloEvento = Console.ReadLine();
    Console.WriteLine();

    Console.Write("Inserisci data dell'evento (gg/mm/yyyy): ");
    string dataEvento = Console.ReadLine();
    Console.WriteLine();

    Console.Write("Inserisci il numero di posti totali: ");
    int capienzaMassima = int.Parse(Console.ReadLine());
    Console.WriteLine();

    try
    {
        Evento evento = new Evento(titoloEvento,dataEvento,capienzaMassima);
        programma.eventi.Add(evento);
    }catch(Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}






