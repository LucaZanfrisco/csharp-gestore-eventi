// See https://aka.ms/new-console-template for more information

using csharp_gestore_eventi;
using System.Runtime.CompilerServices;

Console.Write("Inserire il nome dell'evento: ");
string titolo = Console.ReadLine();

Console.Write("Inserire la data dell'evento: ");
string data = Console.ReadLine();

Console.Write("Inserire il numero di posti totali: ");
int capienzaMassima = int.Parse(Console.ReadLine());

Evento evento = new Evento(titolo, data, capienzaMassima);

Console.Write("\nQuanti posti si desidera prenotare: ");
int postiDaPrenotare = int.Parse(Console.ReadLine());

evento.PostiPrenotati(postiDaPrenotare);

bool controlloDisdetta = false;

while(!controlloDisdetta)
{

    Console.WriteLine($"Numero di posti prenotati = {evento.GetPostiPrenotati()}");
    Console.WriteLine($"Numero di posti disponibili = {evento.GetCapienzaMassima() - evento.GetPostiPrenotati()}");

    Console.WriteLine();

    Console.Write("Desidera disdire dei posti? ");
    string disdire = Console.ReadLine();

    if(disdire.ToLower() == "no")
    {
        break;
    }

    Console.Write("Quanti posti si desidera disdire: ");
    int postiDisdetti = int.Parse(Console.ReadLine());
    evento.DisdiciPosti(postiDisdetti);
}

Console.WriteLine($"Numero di posti prenotati = {evento.GetPostiPrenotati()}");
Console.WriteLine($"Numero di posti disponibili = {evento.GetCapienzaMassima() - evento.GetPostiPrenotati()}");


