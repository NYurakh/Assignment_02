using System.Dynamic;

public interface IHazardNotifier{
    void NotifyHazard(string containerNumber, string messege);
}

public class Container(string serialNumber, double height, double tareWeight, double depth, double maxPayload)
{
    public string SerialNumber { get; } = serialNumber;
    public double CargoMass{get; set;}
    public double Height { get; } = height;
    public double TareWeight { get; } = tareWeight;
    public double Depth { get; } = depth;
    public double MaxPayload { get; } = maxPayload;


public virtual void LoadCargo(double cargoMass){
    if (cargoMass > MaxPayload)
    {
        throw new OverfillException("Cargo is overfilled.");
    }
    CargoMass = cargoMass;
}

public virtual void EmptyCargo()
{
    CargoMass = 0;
}
}
public class OverfillException(string message) : Exception(message)
{
}