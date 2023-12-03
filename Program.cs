using System;
using System.Collections.Generic;

abstract class Vehicle
{
    public int Speed { get; set; }
    public int Capacity { get; set; }

    public abstract void Move();
}

class Human
{
    public int Speed { get; set; }

    public void Move()
    {
        Console.WriteLine("Human is moving...");
    }
}

class Car : Vehicle
{
    public override void Move()
    {
        Console.WriteLine("Car is moving...");
    }
}

class Bus : Vehicle
{
    public override void Move()
    {
        Console.WriteLine("Bus is moving...");
    }
}

class Train : Vehicle
{
    public override void Move()
    {
        Console.WriteLine("Train is moving...");
    }
}

class Route
{
    public string StartPoint { get; set; }
    public string EndPoint { get; set; }
}

class TransportNetwork
{
    private List<Vehicle> vehicles;
    private List<Route> routes;

    public TransportNetwork()
    {
        vehicles = new List<Vehicle>();
        routes = new List<Route>();
    }

    public void AddVehicle(Vehicle vehicle)
    {
        vehicles.Add(vehicle);
    }

    public void AddRoute(Route route)
    {
        routes.Add(route);
    }

    public void CalculateOptimalRoute(string startPoint, string endPoint, Vehicle vehicle)
    {
        // Логіка розрахунку оптимального маршруту залежно від виду транспорту
        Console.WriteLine($"Calculating the optimal route from {startPoint} to {endPoint} for {vehicle.GetType().Name}...");
    }

    public void PassengerBoarding(Vehicle vehicle, int passengers)
    {
        Console.WriteLine($"{passengers} passengers boarded the {vehicle.GetType().Name}.");
    }

    public void PassengerDisembarking(Vehicle vehicle, int passengers)
    {
        Console.WriteLine($"{passengers} passengers disembarked from the {vehicle.GetType().Name}.");
    }
}

class Program
{
    static void Main()
    {
        TransportNetwork transportNetwork = new TransportNetwork();

        Car car = new Car { Speed = 60, Capacity = 5 };
        Bus bus = new Bus { Speed = 40, Capacity = 30 };
        Train train = new Train { Speed = 100, Capacity = 200 };

        transportNetwork.AddVehicle(car);
        transportNetwork.AddVehicle(bus);
        transportNetwork.AddVehicle(train);

        Route route1 = new Route { StartPoint = "A", EndPoint = "B" };
        Route route2 = new Route { StartPoint = "B", EndPoint = "C" };

        transportNetwork.AddRoute(route1);
        transportNetwork.AddRoute(route2);

        foreach (var vehicle in transportNetwork.vehicles)
        {
            transportNetwork.CalculateOptimalRoute(route1.StartPoint, route1.EndPoint, vehicle);
            transportNetwork.PassengerBoarding(vehicle, vehicle.Capacity / 2);
            vehicle.Move();
            transportNetwork.PassengerDisembarking(vehicle, vehicle.Capacity / 2);
        }
    }
}
