using System;

namespace MainApplication
{
    internal class SomeAlgorithm
    {
        public static int MagicCalculation(int arg)
        {
            if (arg < 0)
                throw new ArgumentException("value should be equal to or greater than 0");
            if (arg % 2 == 0)
                return arg / 2;
            return -arg + 1;
        }


        public static Data GetAdmin()
        {
            return new Data
            {
                FirstName = "John",
                LastName = "Smith",
                Age = 43
            };
        }
    }

    internal class Data
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}