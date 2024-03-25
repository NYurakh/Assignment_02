
namespace Assignment_02.Container;

public class LiquidContainer : IContainer, IHazardNotifier
{
    private static int cont_id = 1;
    private static Liquid _liquid;
    private bool _dangerous;

    public double Depth { get; }
    public double MaxPayload { get; }
    public string SerialNumber { get; }
    public double Height { get; }
    public string Type { get; }
    public double CargoMass { get; set; }
    public double TareWeight { get; }

    public LiquidContainer(double cargoMass, double height, double tareWeight, double depth, double maxPayload, Liquid liquid)
    {
        CargoMass = cargoMass;
        Height = height;
        TareWeight = tareWeight;
        Depth = depth;
        MaxPayload = maxPayload;
        Type = "LIQUID";
        _liquid = liquid;
        SerialNumber = CreateNumber(Type);
        _dangerous = IsHazardous();
    }

    public string CreateNumber(string type)
    {
        string number = "KON-" + type[0] + "-" + cont_id;
        cont_id++;
        return number;
    }

    public void LoadCargo(double weight)
    {
        if (_dangerous)
        {
            if (CargoMass + weight >= MaxPayload / 2.0)
            {
                NotifyHazard(SerialNumber, "Is trying to perform an unsafe action. Someone wants to fill the container with hazardous liquid by more than 50%");
                return;
            }
        }
        else
        {
            if (CargoMass + weight >= MaxPayload - MaxPayload / 2.0)
            {
                NotifyHazard(SerialNumber, "Is trying to perform an unsafe action. Someone wants to fill the container with liquid by more than 90%");
                return;
            }
        }
        CargoMass += weight;
    }

    public void EmptyCargo()
    {
        CargoMass = 0;
    }

    public void InfoOutput()
    {
        Console.WriteLine($"Container Type: {Type}");
        Console.WriteLine($"Serial Number: {SerialNumber}");
        Console.WriteLine($"MaxPayload: {MaxPayload}");
        Console.WriteLine($"Height: {Height}");
        Console.WriteLine($"Depth: {Depth}");
        Console.WriteLine($"CargoMass: {CargoMass}");
        Console.WriteLine($"TareWeight: {TareWeight}");

    }

    public void NotifyHazard(string containerNumber, string message)
    {
        Console.WriteLine($"Hazard Notification: Container {containerNumber} - {message}");
    }

    bool IsHazardous()
    {
        return _liquid == Liquid.Fuel || _liquid == Liquid.Accid;
    }
}
