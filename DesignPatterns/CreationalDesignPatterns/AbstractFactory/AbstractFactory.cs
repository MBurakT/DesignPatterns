using System;

namespace DesignPatterns.CreationalDesignPatterns.AbstractFactory;

public class AbstractFactoryProgram
{
    public static void Cient(string[] args)
    {
        IVehicleFactory regularVehicleFactory = new RegularVehicleFactory();

        IBike regularBike = regularVehicleFactory.CreateBike();
        regularBike.GetDetails();

        ICar regularCar = regularVehicleFactory.CreateCar();
        regularCar.GetDetails();

        IVehicleFactory sportsVehicleFactory = new SportsVehicleFactory();

        IBike sportsBike = sportsVehicleFactory.CreateBike();
        sportsBike.GetDetails();

        ICar sportsCar = sportsVehicleFactory.CreateCar();
        sportsCar.GetDetails();
    }
}

public interface IBike
{
    void GetDetails();
}

public interface ICar
{
    void GetDetails();
}

public class RegularBike : IBike
{
    public void GetDetails()
    {
        Console.WriteLine("Fetching RegularBike Details..");
    }
}

public class SportsBike : IBike
{
    public void GetDetails()
    {
        Console.WriteLine("Fetching SportsBike Details..");
    }
}

public class RegularCar : ICar
{
    public void GetDetails()
    {
        Console.WriteLine("Fetching RegularCar Details..");
    }
}

public class SportsCar : ICar
{
    public void GetDetails()
    {
        Console.WriteLine("Fetching SportsCar Details..");
    }
}

public interface IVehicleFactory
{
    IBike CreateBike();
    ICar CreateCar();
}

public class RegularVehicleFactory : IVehicleFactory
{
    public IBike CreateBike()
    {
        return new RegularBike();
    }

    public ICar CreateCar()
    {
        return new RegularCar();
    }
}

public class SportsVehicleFactory : IVehicleFactory
{
    public IBike CreateBike()
    {
        return new SportsBike();
    }

    public ICar CreateCar()
    {
        return new SportsCar();
    }
}