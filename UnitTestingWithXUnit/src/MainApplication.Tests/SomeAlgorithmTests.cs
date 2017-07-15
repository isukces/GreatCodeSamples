using System;
using Xunit;

namespace MainApplication.Tests
{
    /*
        We have access to internal members of MainApplication because of InternalsVisibleTo attribute
    */
    public class SomeAlgorithmTests
    {
        [Fact]
        public void T01_Should_compute_MagicCalculation()
        {
            Assert.Equal(0, SomeAlgorithm.MagicCalculation(1));
            Assert.Equal(1, SomeAlgorithm.MagicCalculation(2));
            Assert.Equal(-2, SomeAlgorithm.MagicCalculation(3));
        }


        [Theory]
        [InlineData(1, 0)]
        [InlineData(2, 1)]
        [InlineData(3, -2)]
        public void T02_Should_compute_MagicCalculation_for_data_serie(int input, int expected)
        {
            Assert.Equal(0, SomeAlgorithm.MagicCalculation(1));
            Assert.Equal(1, SomeAlgorithm.MagicCalculation(2));
            Assert.Equal(-2, SomeAlgorithm.MagicCalculation(3));
        }


        [Theory]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-4)]
        [InlineData(-100)]
        [InlineData(int.MinValue)]
        public void T03_Should_throw_exception_for_negative_values(int arg)
        {
            Assert.Throws<ArgumentException>(() => SomeAlgorithm.MagicCalculation(arg));
        }


        [Fact]
        public void T04_Should_get_valid_admin_data()
        {
            var admin = SomeAlgorithm.GetAdmin();
            Assert.NotNull(admin);
            Assert.NotNull(admin.LastName);
            Assert.NotNull(admin.FirstName);
            Assert.True(admin.FirstName.Length > 3);
            Assert.True(admin.LastName.Length > 3);
            Assert.True(admin.Age > 24);
        }
    }
}