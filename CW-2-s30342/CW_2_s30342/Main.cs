namespace CW_2_s30342;


public class main
{
    public static void Main(string[] args)
    {
        Kontenerowiec kontenerowiec = new Kontenerowiec(40, 200, 1500);
        // alternatywne : Kontenerowiec kontenerowiec = new Kontenerowiec(40, 2, 1500); -> nie będziemy mogli dodać kontenerów
       Kontener k1 = Kontenerowiec.StworzKontener("Chlod", 10, 5, 6.6, 100); //napisz nr. 10
        Kontener k2 = Kontenerowiec.StworzKontener("Gaz", 40, 3, 6.3, 40);
        Kontener k3 = Kontenerowiec.StworzKontener("Plyn", 16, 10, 8.6, 200);
        Kontener k4 = Kontenerowiec.StworzKontener("Chlod", 11, 12, 6.6, 400); //napisz np. 20
        Kontener k5 = Kontenerowiec.StworzKontener("Gaz", 12, 5, 6.3, 50);
        Kontener k6 = Kontenerowiec.StworzKontener("Plyn", 13, 8, 8.6, 130);
        Kontenerowiec.ZaladujKontener(k1, 40); //napisz np.Butter
       Kontenerowiec.ZaladujKontener(k2, 30); 
       Kontenerowiec.ZaladujKontener(k3, 70); //napisz np. nie
       Kontenerowiec.ZaladujKontener(k4, 120); //napisz np. Meat
       Kontenerowiec.ZaladujKontener(k5, 20);
       Kontenerowiec.ZaladujKontener(k6, 120);//napisz np. tak
       //alternatywne: Kontenerowiec.ZaladujKontener(k3, 210);
       
       kontenerowiec.ZaladujnaStatek(k1);
      kontenerowiec.ZaladujnaStatek(new List<Kontener>() { k2, k3, k4, k5 });
        
       kontenerowiec.usunKontener("KON-C-0");

       Kontenerowiec inny = new Kontenerowiec(5, 2, 3400);
       kontenerowiec.PrzeniesKontener("KON-G-1", inny);
       kontenerowiec.rozladujKontener("KON-L-2");
       kontenerowiec.ZamianaKontenerow("KON-G-4", k6);
       
       Console.WriteLine(kontenerowiec);
       Console.WriteLine(inny);


    }
}