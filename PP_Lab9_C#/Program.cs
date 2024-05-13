using System;
using System.Collections.Generic;

public class Car
{
    public string Model { get; set; }

    public Car(string model)
    {
        Model = model;
    }
}

public class Garage
{
    private List<Car> cars;

    public Garage()
    {
        cars = new List<Car>();
    }

    public void Park(Car car)
    {
        cars.Add(car);
    }

    public delegate void WashCar(Car car);
    public void WashAllCars(WashCar washCar)
    {
        foreach (var car in cars)
        {
            washCar(car);
        }
    }
}

public class Washer
{
    public void Wash(Car car)
    {
        Console.WriteLine($"Машина {car.Model} вымыта!");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Car car1 = new Car("ВАЗ");
        Car car2 = new Car("БМВ");

        Garage garage = new Garage();
        garage.Park(car1);
        garage.Park(car2);

        Washer washer = new Washer();
        
        Garage.WashCar washCar = washer.Wash;
        garage.WashAllCars(washCar);
    }
}