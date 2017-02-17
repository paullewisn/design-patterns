using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Design_Patterns
{
    public class Strategy
    {
        public static readonly ReadOnlyCollection<Vehicle> Vehicles = new List<Vehicle>
        {
            new Vehicle { Name = "Car", Wheels = 4 },
            new Vehicle { Name = "Truck", Wheels = 16 },
            new Vehicle { Name = "Train", Wheels = 200 },
            new Vehicle { Name = "Motorbike", Wheels = 2 }
        }.AsReadOnly();

        public List<Vehicle> SortByName()
        {
            var list = Vehicles.ToList();
            list.Sort(new NameComparer());
            return list;
        }

        public List<Vehicle> SortByWheels()
        {
            var list = Vehicles.ToList();
            list.Sort(new WheelComparer());
            return list;
        }
    }

    public class WheelComparer : IComparer<Vehicle>
    {
        public int Compare(Vehicle x, Vehicle y)
        {
            return x.Wheels.CompareTo(y.Wheels);
        }
    }

    public class NameComparer : IComparer<Vehicle>
    {
        public int Compare(Vehicle x, Vehicle y)
        {
            return string.Compare(x.Name, y.Name, StringComparison.Ordinal);
        }
    }

    [TestFixture]
    public class StrategyTest
    {
        [Test]
        public void UseStrategy()
        {
            var strategy = new Strategy();
            var vehicleList = strategy.SortByName();
            StringAssert.AreEqualIgnoringCase("Car", vehicleList[0].Name);
            vehicleList = strategy.SortByWheels();
            Assert.AreEqual(2, vehicleList[0].Wheels);
        }
    }

    public class Vehicle
    {
        public string Name { get; set; }
        public int Wheels { get; set; }
    }
}
