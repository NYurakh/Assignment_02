namespace Assignment_02.Container;

public class GasContainer : IContainer, IHazardNotifier
{
    private static int cont_id = 1;

    public GasContainer(double cargoMass, double height, double tareWeight, double depth, double maxPayload, double pressure)
    {
        CargoMass = cargoMass;
        Height = height;
        TareWeight = tareWeight;
        Depth = depth;
        MaxPayload = maxPayload;
        Pressure = pressure;
        Type = "GAS";
        SerialNumber = CreateNumber(Type);
    }

    public double Depth { get; }
    public double MaxPayload { get; }
    public string SerialNumber { get; }
    public double Height { get; }
    public string Type { get; }
    public double CargoMass { get; set; }
    public double TareWeight { get; }
    private double Pressure { get; }

    public string CreateNumber(string type)
    {
        string number = "KON-" + type[0] + "-" + cont_id;
        cont_id++;
        return number;
    }

    public void LoadCargo(double weight)
    {
        if (CargoMass + weight > MaxPayload)
        {
            NotifyHazard(SerialNumber, "Cargo mass exceeds maximum payload.");
        }
        else
        {
            CargoMass += weight;
        }
    }

    public void EmptyCargo()
    {
        CargoMass = CargoMass * 5 / 100;
    }

    public void InfoOutput()
    {
        Console.WriteLine($"Container Type: {Type}");
        Console.WriteLine($"Serial Number: {SerialNumber}");
        Console.WriteLine($"MaxPayload: {MaxPayload}");
        Console.WriteLine($"Height: {Height}");
        Console.WriteLine($"Depth: {Depth}");
        Console.WriteLine($"CargoMass: {CargoMass}");
        Console.WriteLine($"Preassure: {Pressure}");
        Console.WriteLine($"TareWeight: {TareWeight}");

    }

    public void NotifyHazard(string containerNumber, string message)
    {
        Console.WriteLine($"Hazard Notification: Container {containerNumber} - {message}");
    }
}
