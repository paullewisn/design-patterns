using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Design_Patterns
{
    public struct Duration
    {
        private Duration(long ticks)
        {
            this.Ticks = ticks;
        }

        public long Ticks { get; }

        public static Duration FromTicks(long ticks)
        {
            return new Duration(ticks);
        }

        public static Duration FromSeconds(long seconds)
        {
            return new Duration(seconds*10000*1000);
        }

        public static Duration FromMilliSeconds(long milliseconds)
        {
            return new Duration(milliseconds*10000);
        }
    }

    [TestFixture]
    public class FactoryTest
    {
        [Test]
        public void UseFactory()
        {
            const int input = 5;
            
            var duration = Duration.FromMilliSeconds(input);
            Assert.AreEqual(duration.Ticks, input*10000);

            duration = Duration.FromSeconds(input);
            Assert.AreEqual(duration.Ticks, input*10000*1000);

            duration = Duration.FromTicks(input);
            Assert.AreEqual(duration.Ticks, input);

        }
    }
}
