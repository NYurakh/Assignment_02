public class Ship
    {
        private List<IContainer> _containers;
        private int _maxCapacity;
        private double _maxToLoad;

        public Ship(List<IContainer> containers, int capacity, double load)
        {
            _containers = containers;
            _maxCapacity = capacity;
            _maxToLoad = load;
        }

        public Ship(int capacity, double load)
        {
            _containers = new List<IContainer>();
            _maxCapacity = capacity;
            _maxToLoad = load;
        }

        public override string ToString()
        {
            if (_containers.Count > 0)
            {
                return $"Ship has {_containers.Count} containers with total weight {GetTotalWeight()} tons.";
            }
            else
            {
                return "The ship is empty.";
            }
        }

        public double GetTotalWeight()
        {
            double totalWeight = 0;
            foreach (var container in _containers)
            {
                totalWeight += container.CargoMass + container.TareWeight;
            }
            return totalWeight;
        }

        public void LoadContainer(IContainer container)
        {
            if (_containers.Count >= _maxCapacity)
            {
                throw new ShipException("The maximum number of containers have been loaded.");
            }

            if (GetTotalWeight() + container.CargoMass + container.TareWeight > _maxToLoad)
            {
                throw new ShipException("Cannot load, the weight will be too big.");
            }

            _containers.Add(container);
        }
    }

    public class ShipException : Exception
    {
        public ShipException() { }
        public ShipException(string message) : base(message) { }
        public ShipException(string message, Exception innerException) : base(message, innerException) { }
    }
