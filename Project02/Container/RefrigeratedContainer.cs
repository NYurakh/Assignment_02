using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Assignment_02.Container
{
    public class RefrigeratedContainer : IContainer
    {
        private static int cont_id = 1;
        private static Dictionary<Products, double> _temperatureMap = new Dictionary<Products, double>();

        private double _temperature;
        private Products _products;

        public double Depth { get; }
        public double MaxPayload { get; }
        public string SerialNumber { get; }
        public double Height { get; }
        public string Type { get; }
        public double CargoMass { get; set; }
        public double TareWeight { get; }

        public RefrigeratedContainer(double temperature, double cargoMass, int height, int tareWeight, int depth, double maxPayload, Products products)
        {
            _temperature = temperature;
            _products = products;
            CargoMass = cargoMass;
            Height = height;
            TareWeight = tareWeight;
            Depth = depth;
            MaxPayload = maxPayload;
            Type = "REFRIGERATED";
            SerialNumber = CreateNumber(Type);
        }

        public string CreateNumber(string type)
        {
            string number = "KON-C-" + cont_id;
            cont_id++;
            return number;
        }

        public void EmptyCargo()
        {
            CargoMass = 0;
        }

        public void LoadCargo(double weight)
        {
            if (weight > MaxPayload)
            {
                throw new OverfillException("Cargo weight exceeds the maximum payload of the container.");
            }

            CargoMass += weight;
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
            Console.WriteLine($"Products: {_products}");
        }

        public void NotifyHazard()
        {
            Console.WriteLine($"Hazardous situation detected for container: {SerialNumber}");
        }


        public void LoadCargo(double weight, Products product)
        {
            if (product != _products)
            {
                throw new ProductException("Attempted to load cargo of different product type.");
            }

            LoadCargo(weight);
        }


        private void ValidateTemperature()
        {
            if (!_temperatureMap.ContainsKey(_products))
            {
                throw new ArgumentException("Product temperature not found in the temperature map.");
            }

            double allowedTemperature = _temperatureMap[_products];
            if (Math.Abs(_temperature - allowedTemperature) > 2)
            {
                throw new TemperatureException("The temperature differs by more than 2 degrees.");
            }
        }
    }

    [Serializable]
    internal class OverfillException : Exception
    {
        public OverfillException()
        {
        }

        public OverfillException(string? message) : base(message)
        {
        }

        public OverfillException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected OverfillException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    internal class TemperatureException : Exception
    {
        public TemperatureException()
        {
        }

        public TemperatureException(string? message) : base(message)
        {
        }

        public TemperatureException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected TemperatureException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    internal class ProductException : Exception
    {
        public ProductException()
        {
        }

        public ProductException(string? message) : base(message)
        {
        }

        public ProductException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ProductException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
