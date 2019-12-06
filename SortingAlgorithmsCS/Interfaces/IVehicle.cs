namespace SortingAlgorithmsCS.Interfaces
{
    interface IVehicle
    {
        string make { get; set; }
        string model { get; set; }
        string registration { get; set; }
        int currentState { get; set; }

        void start();
        void run();
        void stop();
    }
}
