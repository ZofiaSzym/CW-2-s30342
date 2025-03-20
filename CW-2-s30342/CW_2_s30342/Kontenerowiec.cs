namespace CW_2_s30342;

public class Kontenerowiec
{
    List<Kontener> _list = new List<Kontener>();
    private int _wezly;
    private int _maxKonten;
    private int _maxWaga;

    public Kontenerowiec(int wezly, int maxKonten, int maxWaga)
    {
        _wezly = wezly;
        _maxKonten = maxKonten;
        _maxWaga = maxWaga;
    }

    public List<Kontener> List => _list;

    public int MaxWaga => _maxWaga;

    public int MaxKonten => _maxKonten;

    //tworzy kontener i oddaje go w return
    public static Kontener StworzKontener(string typ, double wysokosc, double wagaWlasna, double glebokosc, double maxMasa) {
        bool zrobiony = false;
        Kontener k = null;
        double wagaTeraz =0;
        
            switch (typ)
            {
                case "Plyn":
                    k = new PlynKontener(wysokosc, wagaWlasna, Globals._liczba.ToString(), glebokosc, maxMasa);
                    break;
                case "Gaz":
                    k =new GazKontener(wysokosc, wagaWlasna, Globals._liczba.ToString(), glebokosc, maxMasa);
                    break;
                case "Chlod":
                    Console.WriteLine("w jakiej temperaturze chcesz stworzyć kontener Chłodzący?");
                    double temperatura = Convert.ToDouble(Console.ReadLine());
                    k = new ChlodKontener(wysokosc, wagaWlasna, Globals._liczba.ToString(), glebokosc, maxMasa, temperatura);
                    break;
                default:
                    throw new Exception("Nie mozna stworzyc takiego kontenera");
            }

            Globals._liczba++;

        return k;
    }

    //uzupełnia zawartość kontenera
    public static void ZaladujKontener(Kontener k, Double towar)
    {
        k.zapelnij(towar);
    }

    //przyjmuje jeden kontener, dodaje go na statek
    public void ZaladujnaStatek(Kontener k) {
        double wagaTeraz =0;
        for (int i = 0; i < _list.Count; i++){
            wagaTeraz = wagaTeraz + _list[i].getWagaCala();
        }
        
        if (_list.Count < _maxKonten &&  k.getWagaCala()+wagaTeraz < _maxWaga ) {
          _list.Add(k);
        }
        else
        {
            Console.WriteLine($"Niestety nie możesz dodać tego kontenera. Możliwe miejsca na kontenery to {_maxKonten - _list.Count}, a możliwa waga {_maxWaga - wagaTeraz}");
        }
    }

    //przyjmuje liste kontenerów, załadowuje je na statek
    public void ZaladujnaStatek(List<Kontener> lista)  {
        double wagaTeraz =0;
        double wagaListy = 0;
        for (int i = 0; i < _list.Count; i++){
            wagaTeraz = wagaTeraz + _list[i].getWagaCala();
        }
        
        for (int i = 0; i < lista.Count; i++){
            wagaListy = wagaListy + lista[i].getWagaCala();
        }
        
        if (_list.Count+lista.Count < _maxKonten &&  wagaListy+wagaTeraz < _maxWaga ) {
            for (int i = 0; i < lista.Count; i++)
            {
                _list.Add(lista[i]);
            }
        }
        else
        {
            Console.WriteLine($"Nie możesz dodać tych kontenerów na statek. Możliwe miejsca na kontenery to {_maxKonten - _list.Count}, a możliwa waga {_maxWaga - wagaTeraz}");
        }
    }
    
    //przyjmuje nr unikalny kontenera i usuwa go ze statku
    public void usunKontener(string nr)
    {
        for (int i = 0; i < _list.Count; i++) {
            if (nr == _list[i].Nr) {
                _list.RemoveAt(i);
                Console.WriteLine($"Usunięto kontener {nr}");
                break;
            }
        }
    }
    
//usuwa zawartość kontenera
    public void rozladujKontener(string nr)
    {
        for (int i = 0; i < _list.Count; i++) {
            if (nr == _list[i].Nr) {
                _list[i].oproznij();
                Console.WriteLine($"Rozładowano kontener {nr}");
                break;
            }
        }
    }
    
    //zamiana kontenerów

    public void ZamianaKontenerow(string pocz,Kontener konc) {
        double wagaTeraz =0;
        
        for (int i = 0; i < _list.Count; i++){
            wagaTeraz = wagaTeraz + _list[i].getWagaCala();
        }
        
        for (int i = 0; i < _list.Count; i++) {
            if (pocz == _list[i].Nr) {
                if (wagaTeraz - _list[i].getWagaCala() + konc.getWagaCala() <= _maxWaga)
                {
                    _list.RemoveAt(i);
                    _list.Add(konc);
                    Console.WriteLine($"Usunięto kontener {pocz} na poczet kontenera {konc.Nr}");
                    break;
                }
                else
                {
                    Console.WriteLine($"Waga dodawanego kontenera jest za duża");
                }
            }
        }
    }
    
    //przeniesienie kontenera za pomoca oddania go innemu statkowi
    public void PrzeniesKontener(string nr, Kontenerowiec inny)
    {
        double wagaTeraz =0;
        
        for (int i = 0; i < inny.List.Count; i++){
            wagaTeraz = wagaTeraz + inny.List[i].getWagaCala();
        }

        if (inny.List.Count < inny.MaxKonten) {
            for (int i = 0; _list.Count > i; i++)
            {
                if (_list[i].Nr == nr)
                {
                    if (wagaTeraz + _list[i].getWagaCala() <= inny.MaxWaga)
                    {
                        inny._list.Add(_list[i]);
                        _list.RemoveAt(i);
                    }
                    else
                    {
                        Console.WriteLine("Waga kontenera jest za duża na drugi kontenerowiec");
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("Drugi kontenerowiec jest pełny ");
        }
        
    }

    public override string ToString()
    {
        String reply = null;
        for (int i = 0; i < _list.Count; i++)
        {
            reply += $"{_list[i]} \n";
        }

        return $"""
                Kontenerowiec z {_list.Count} Kontenerami, o prędkości {_wezly}węzłów,
                 o maksymalnej ilości kontenerów {_maxKonten} o wadze maksymalnej {_maxWaga}kg.
                 
                  {reply} 
                """;
    }
}