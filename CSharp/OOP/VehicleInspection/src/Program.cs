namespace src
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string carBrand = "Audi";
            string carModel = "A6";
            DateOnly carProductionDate = new(2018, 7, 1);
            DateTime carLastInspection = new(2022, 12, 8, 12, 34, 56);
            Vehicle car = new Car(carBrand, carModel, carProductionDate, carLastInspection);

            string truckBrand = "Volvo";
            string truckModel = "A6";
            DateOnly truckProductionDate = new(2018, 10, 1);
            DateTime truckLastInspection = new(2021, 10, 1, 12, 34, 56);
            Vehicle truck = new Truck(truckBrand, truckModel, truckProductionDate, truckLastInspection);

            Console.WriteLine(car.DisplayInfo());
            Console.WriteLine(car.InspectionStatus());
            Console.WriteLine();
            Console.WriteLine(truck.DisplayInfo());
            Console.WriteLine(truck.InspectionStatus());
        }
    }
}
