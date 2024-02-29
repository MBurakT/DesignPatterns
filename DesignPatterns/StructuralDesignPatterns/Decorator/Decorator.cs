using System;

namespace DesignPatterns.StructuralDesignPatterns.Decorator;

public class DecoratorProgram
{
    public static void Client(string[] args)
    {
        ICar firstCar = new BMW();
        ICar secondCar = new BMW();

        firstCar.ManufactureCar();
        secondCar.ManufactureCar();

        Console.WriteLine(firstCar);
        Console.WriteLine(secondCar);

        DieselCarDecorator dieselCarDecorator = new(firstCar);
        PetrolCarDecorator petrolCarDecorator = new(secondCar);

        dieselCarDecorator.ManufactureCar();
        petrolCarDecorator.ManufactureCar();

        Console.WriteLine(firstCar);
        Console.WriteLine(secondCar);
    }
}

public interface ICar
{
    ICar ManufactureCar();
}

public class BMW : ICar
{
    private string carName = "BMW";
    public string? CarBody { get; set; }
    public string? CarDoor { get; set; }
    public string? CarWheels { get; set; }
    public string? CarGlass { get; set; }
    public string? Engine { get; set; }

    public ICar ManufactureCar()
    {
        CarBody = "carbon fiber material";
        CarDoor = "4 car doors";
        CarWheels = "4 MRF wheels";
        CarGlass = "6 car glasses";
        return this;
    }

    public override string ToString()
    {
        return $"BMW [CarName={carName}, CarBody={CarBody}, CarDoor={CarDoor}, CarWheels={CarWheels}, CarGlass={CarGlass}, Engine={Engine}]";
    }
}

public abstract class CarDecorater : ICar
{
    protected ICar car;

    public CarDecorater(ICar car)
    {
        this.car = car;
    }

    public virtual ICar ManufactureCar()
    {
        return car.ManufactureCar();
    }
}

class DieselCarDecorator : CarDecorater
{
    public DieselCarDecorator(ICar car) : base(car) { }

    public override ICar ManufactureCar()
    {
        car.ManufactureCar();
        AddEngine(car);

        return car;
    }

    public void AddEngine(ICar car)
    {
        if (car is BMW bMW)
        {
            bMW.Engine = "Diesel Engine";
        }
    }
}

class PetrolCarDecorator : CarDecorater
{
    public PetrolCarDecorator(ICar car) : base(car) { }

    public override ICar ManufactureCar()
    {
        car.ManufactureCar();
        AddEngine(car);

        return car;
    }

    public void AddEngine(ICar car)
    {
        if (car is BMW bMW)
        {
            bMW.Engine = "Petrol Engine";
        }
    }
}