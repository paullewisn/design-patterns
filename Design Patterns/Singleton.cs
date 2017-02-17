using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Design_Patterns
{
    //only allows one instance
    public class Singleton
    {
        //thread safe version
        //only one thread can be in a static initialiser 
        private static readonly Singleton instance = new Singleton();

        private Singleton()
        {
            //constructor only called once
        }

        public static Singleton Instance
        {
            get { return instance; }
        }
    }

    [TestFixture]
    public class SingletonTest
    {
        [Test]
        public void UseSingleton()
        {
            var s1Singleton = Singleton.Instance;
            var s2Singleton = Singleton.Instance;
            Assert.AreSame(s1Singleton, s2Singleton);
            // .AreSame compares references to objects
        }
    }
}
