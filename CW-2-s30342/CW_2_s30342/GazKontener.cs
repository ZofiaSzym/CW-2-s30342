namespace CW_2_s30342;

public class GazKontener : Kontener, IHazardNotifier
{
    private double _cisnienie;


    public GazKontener(double wysokosc, double wagaWlasna, string nr, double glebokosc, double maxMasa, double cisnienie) : base(wysokosc, wagaWlasna, nr, glebokosc, maxMasa)
    {
        base._nr = $"KON-G-{nr}";
        this._cisnienie = cisnienie;
    }

    public void Notify()
    {
        Console.WriteLine($"GazKontener {_nr} jest w zapelniany, uwazaj na cisnienie!");
    }

    public override void oproznij()
    {
        double pozostaw = _masa * 0.05;
        base.oproznij();
        _masa += pozostaw;
        _cisnienie = (_masa * 10) / (_wysokosc * _glebokosc);
        
    }

    public override void zapelnij(double towar)
    {
        base.zapelnij(towar);
        _cisnienie = (_masa * 10) / (_wysokosc * _glebokosc);
        Notify();
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
                 cisnienie: {this._cisnienie} atmosfer
                """;
    }
}