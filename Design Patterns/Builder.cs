using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using NUnit.Framework;

namespace Design_Patterns
{
    public sealed class HouseBuilder
    {
        private int Bricks { get; set; }
        public int Windows { get; set; }
        public int Doors { get; set; }
        public int Tiles { get; set; }

        public HouseBuilder(int bricks)
        {
            this.Bricks = bricks;
        }

        public House Build()
        {
            return new House(Bricks, Windows, Doors, Tiles);
        }
    }

    public class House
    {
        public int Bricks { get; }
        public int Windows { get; }
        public int Doors { get; }
        public int Tiles { get; }

        public House(int bricks, int windows, int doors, int tiles)
        {
            Bricks = bricks;
            Windows = windows;
            Doors = doors;
            Tiles = tiles;
        }
    }

    [TestFixture]
    public class BuilderTest
    {
        [Test]
        public void UseBuilder()
        {
            var house = new HouseBuilder(500) {Doors = 2, Tiles = 300, Windows = 10}.Build();
            Assert.AreEqual(house.Bricks, 500);
            Assert.AreEqual(house.Doors, 2);
            Assert.AreEqual(house.Tiles, 300);
            Assert.AreEqual(house.Windows, 10);
        }
    }
}
