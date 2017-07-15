namespace MainApplication
{
    public interface IDuck
    {
        void Swim();
        bool IsSwimming { get; }
    }

    public class Duck : IDuck
    {
        public void Swim()
        {
            IsSwimming = true;
        }

        public bool IsSwimming { get; set; }
    }

    public class ElectricDuck : IDuck
    {
        public void Swim()
        {
            if (_isTurnedOn)
                IsSwimming = true;
        }

        public void TurnOn()
        {
            _isTurnedOn = true;
        }

        public bool IsSwimming { get; set; }
        private bool _isTurnedOn;
    }
}