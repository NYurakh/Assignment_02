using Assignment_02.Container;

public class Program
    {
        public static void Main(string[] args)
{
    GasContainer gasContainer1 = new GasContainer(100, 100, 100, 100, 1000, 2);
    LiquidContainer liquidContainer1 = new LiquidContainer(100, 100, 100, 100, 1000, Liquid.Milk);
    LiquidContainer liquidContainer2 = new LiquidContainer(100, 100, 100, 100, 1000, Liquid.Fuel);
    LiquidContainer liquidContainer3 = new LiquidContainer(100, 100, 100, 100, 10000, Liquid.Milk);
    RefrigeratedContainer refrigeratedContainer = new RefrigeratedContainer(18, 100, 100, 100, 100, 1000, Products.Bananas);

    try
    {
        gasContainer1.LoadCargo(50);
        liquidContainer1.LoadCargo(150);
        liquidContainer2.LoadCargo(200);
        liquidContainer3.LoadCargo(10);
        refrigeratedContainer.LoadCargo(100);
    }
    catch (OverfillException ex)
    {
        Console.WriteLine(ex.Message);
    }

    gasContainer1.EmptyCargo();

    List<IContainer> containers = new List<IContainer> { gasContainer1, liquidContainer1, liquidContainer2, liquidContainer3, refrigeratedContainer };
    Ship ship = new Ship(containers, 3, 1000);

    try
    {
        ship.LoadContainer(gasContainer1);
        ship.LoadContainer(liquidContainer1);
        ship.LoadContainer(liquidContainer2);
        ship.LoadContainer(liquidContainer3);
        ship.LoadContainer(refrigeratedContainer);
    }
    catch (ShipException ex)
    {
        Console.WriteLine(ex.Message);
    }

    Console.WriteLine(ship.ToString());
}

    }