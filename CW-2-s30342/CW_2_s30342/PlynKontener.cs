namespace CW_2_s30342;

public class PlynKontener : Kontener, IHazardNotifier
{
    public PlynKontener(double wysokosc, double wagaWlasna, string nr, double glebokosc, double maxMasa) :
        base(wysokosc, wagaWlasna, nr, glebokosc, maxMasa)
    {
        base._nr = $"KON-L-{nr}";
    }

    public void Notify()
    {
        Console.WriteLine($"Niebezpieczna sytuacja z {this._nr}" );
    }

    public override void zapelnij(double towar)
    {
        string odp;
        do
        {
            Console.WriteLine($"Uzupełnianie kontenera {_nr} : Czy to niebezpieczny towar? napisz tak/nie");
            odp = Console.ReadLine();
        } while (!odp.Equals("tak") && !odp.Equals("nie"));

        if (odp.Equals("nie"))
        { 
            if (towar > _maxMasa * 0.9) {
                this.Notify();
            }
        } else {
            if (towar > _maxMasa * 0.5) {
                this.Notify();;
            }
        }
        base.zapelnij(towar);
        
    }

    public override string ToString()
    {
        return $"""
                 Kontener na płyn o nr. {this._nr}
                 masa ładunku:  {this._masa} kg
                 masa samego kontenera: {this._wagaWlasna}kg
                 maksymalna ładowność: {this._maxMasa}kg
                 wysokosc: {this._wysokosc} cm
                 glebokosc: {this._glebokosc} cm
                 
                """;
    }
}