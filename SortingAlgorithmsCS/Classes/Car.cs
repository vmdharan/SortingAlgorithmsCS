namespace SortingAlgorithmsCS.Classes
{
    class Car : Vehicle
    {
        public Car(string _make, string _model, string _registration) 
            : base(_make, _model, _registration)
        {
        }

        public override void run()
        {
            currentState = 2;
        }

        public override void start()
        {
            currentState = 1;
        }

        public override void stop()
        {
            currentState = 0;
        }
    }
}
