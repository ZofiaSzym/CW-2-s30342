namespace CW_2_s30342;

public class ChlodKontener : Kontener
{
    private string _rodzajProduktu;
    private double _temperatura;
    private Dictionary<String, Double> _proTotemp;


    public ChlodKontener(double wysokosc, double wagaWlasna, string nr, double glebokosc, double maxMasa, double temperatura) : base(wysokosc, wagaWlasna, nr, glebokosc, maxMasa)
    {
        _nr = $"KON-C-{nr}";
        _temperatura = temperatura;

        _proTotemp = new Dictionary<String, Double> {
            { "Bananas", 13.3 }, { "Chocolate", 18 }, { "Fish", 2 }, { "Meat", -15 }, { "Ice cream", -18 },
            { "Frozen pizza", -30 }, { "Cheese", 7.2 }, { "Sausages", 5 }, { "Butter", 20.5 }, { "Eggs", 19 }
        };
    }

    public override void zapelnij(double towar)
    {
        Console.WriteLine($"Kontener {_nr}: Jaki towar chcesz dołożyć? Temperatura to: {_temperatura}");
        string nowyProdukt = Console.ReadLine();
        if (_rodzajProduktu == nowyProdukt) {
            base.zapelnij(towar);
        } else if (_masa == 0 && _temperatura >= _proTotemp[nowyProdukt]) {
            base.zapelnij(towar);
            _rodzajProduktu = nowyProdukt;
        }
        else
        {
            Console.WriteLine("nie możesz tego zrobić");
        }
    }

    public override void oproznij()
    {
        base.oproznij();
        _rodzajProduktu = null;
    }
    
    public override string ToString()
    {
        return $"""
                 Kontener na produkty chłodzone o nr. {this._nr}
                 rodzaj produktu: {this._rodzajProduktu}
                 temperatura : {this._temperatura} C
                 masa ładunku:  {this._masa} kg
                 masa samego kontenera: {this._wagaWlasna}kg
                 maksymalna ładowność: {this._maxMasa}kg
                 wysokosc: {this._wysokosc} cm
                 glebokosc: {this._glebokosc} cm
                 
                """;
    }
}