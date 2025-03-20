namespace CW_2_s30342;

public class Kontener {
    protected double _masa;
    protected double _wysokosc;
    protected double _wagaWlasna;
    protected double _glebokosc;
    protected string _nr;
    protected double _maxMasa;

    public Kontener(double wysokosc, double wagaWlasna, string nr, double glebokosc, double maxMasa)
    {
        this._masa = 0;
        this._wysokosc = wysokosc;
        this._wagaWlasna = wagaWlasna;
        this._glebokosc = glebokosc;
        this._nr = nr;
        this._maxMasa = maxMasa;
    }

    public virtual void oproznij() {
        _masa = 0;
    }

    public virtual void zapelnij(Double towar)
    {
        if (towar <= _maxMasa-_masa)
        {
            _masa = _masa+towar;
            Console.WriteLine($"Kontener {_nr} został zapełniony");
        }
        else
        {
            throw new OverfillException($"{_nr} nie zmieści takiej ilości towaru");
        }
    }

    public double getWagaCala()
    {
        return _wagaWlasna+_masa;
    }

    public string Nr => _nr;

    public virtual string toString()
    {
        return base.ToString();
    }
}


