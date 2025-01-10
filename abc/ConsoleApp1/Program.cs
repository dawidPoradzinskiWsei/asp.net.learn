// zmienne
// typZmiennej nazwaZmiennej = wartość;
// int -> liczba
// string -> tekst
// bool -> prawda/fałsz

static string ZrobAnagram(string slowo)
{
    //stworzenie maszyny losującej i zmiennej która zapiszę nam końcowy anagram
    Random r = new Random();
    string anagram = "";
    //stworzenie listy literek z wybranego słowa
    List<char> litery = new List<char>(slowo);
 
    //rozlosowanie literek na nowe miejsca
    for(int i = 0; i < slowo.Length; i++)
    {
        //losowanie litery którą teraz ustawimy
        int wylosowanaPozycja = r.Next(litery.Count);
        //ustawienie litery na nowej pozycji
        anagram += litery[wylosowanaPozycja];
        //usunięcie litery z listy literek bo już jest ustawiona
        litery.RemoveAt(wylosowanaPozycja);
    }
    return anagram;
}

int wiek = 23;
string imie = "Dawid";
bool czyStudent = true;

Console.WriteLine(imie);
Console.WriteLine(wiek);
Console.WriteLine(czyStudent);

List<string> listaZakupow = new List<string>() {"mleko","chleb","masło"};

Random maszynaLosujaca = new Random();

string wylosowaneSlowo = listaZakupow[maszynaLosujaca.Next( listaZakupow.Count )];
string anagram = ZrobAnagram(wylosowaneSlowo);

string odpowiedz = "";
int liczbaOperacji = 0;

System.Console.WriteLine(anagram);

do
{
    liczbaOperacji++;
    odpowiedz = Console.ReadLine();
    if( odpowiedz == wylosowaneSlowo )
    {
        Console.WriteLine("Brawo! Zgadłeś!");
    }
    else
    {
        Console.WriteLine("Spróbuj jeszcze raz!");
    }
} while( odpowiedz != wylosowaneSlowo );

System.Console.WriteLine($"Zgadłeś za {liczbaOperacji} razem!");