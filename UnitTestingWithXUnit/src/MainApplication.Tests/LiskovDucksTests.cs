using Xunit;

namespace MainApplication.Tests
{
    public class LiskovDucksTests
    {
        [Fact]
        public void T01_Duck_should_swimm()
        {
            CheckDuckContracts(new Duck());
        }

        /// <summary>
        /// ElectricDuck break Liskov rule
        /// </summary>
        [Fact]        
        public void T02_ElectricDuck_should_swimm()
        {
            CheckDuckContracts(new ElectricDuck());
        }

        private static void CheckDuckContracts(IDuck duck)
        {
            Assert.False(duck.IsSwimming);
            duck.Swim();
            Assert.True(duck.IsSwimming);
        }
    }
}