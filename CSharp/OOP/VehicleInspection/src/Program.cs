namespace src
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string carBrand = "Audi";
            string carModel = "A6";
            DateTime carProductionDate = new(2018, 7, 1);
            //DateTime carLastInspection = new(2021, 12, 8); /*NOT ALLOWED TO DRIVE*/
            DateTime carLastInspection = new(2024, 12, 8); /*ALLOWED TO DRIVE*/
            Vehicle car = new Car(carBrand, carModel, carProductionDate, carLastInspection);

            string truckBrand = "Volvo";
            string truckModel = "H6";
            DateTime truckProductionDate = new(2018, 10, 1);
            DateTime truckLastInspection = new(2021, 10, 1); /*NOT ALLOWED TO DRIVE*/
            //DateTime truckLastInspection = new(2024, 10, 1); /*ALLOWED TO DRIVE*/
            Vehicle truck = new Truck(truckBrand, truckModel, truckProductionDate, truckLastInspection);

            Console.WriteLine(car.DisplayInfo());
            Console.WriteLine(car.InspectionStatus());
            Console.WriteLine($"Summer Rim Size: {car.MaxRimSize}");
            car.SetTireType(true);
            Console.WriteLine($"Winter Rim Size: {car.MaxRimSize}");
            Console.WriteLine();
            Console.WriteLine(truck.DisplayInfo());
            Console.WriteLine(truck.InspectionStatus());
            Console.WriteLine($"Summer Rim Size: {truck.MaxRimSize}");
            truck.SetTireType(true);
            Console.WriteLine($"Winter Rim Size: {truck.MaxRimSize}");

            Console.WriteLine(car.GetInterfaceInfo());
            Console.WriteLine(truck.GetInterfaceInfo());
        }
    }
}
