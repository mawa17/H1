namespace src
{
    public abstract class Vehicle
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateOnly ProductionDate { get; set; }
        public DateTime LastInspection { get; set; }

        private protected Vehicle(in string brand, in string model, in DateOnly productionDate, in DateTime lastInspection)
        {
            this.Brand = brand;
            this.Model = model;
            this.ProductionDate = productionDate;
            this.LastInspection = lastInspection;
        }
        public abstract string InspectionStatus();
        public virtual string DisplayInfo() => $"Brand: {this.Brand}, Model: {this.Model}, Production Date: {this.ProductionDate.ToShortDateString()}";
    }
    public sealed class Car : Vehicle
    {
        public Car(in string brand, in string model, in DateOnly productionDate, in DateTime lastInspectionTime) : base(brand, model, productionDate, lastInspectionTime) { }
        public override string InspectionStatus()
        {
            if (base.ProductionDate.Year > 4 && base.LastInspection.Year > 2) return $"{this.GetType().Name} NEED inspection ASAP and is NOT allowed to drive!";
            return $"{this.GetType().Name} Is good to drive";
        }
        public override string DisplayInfo() => $"Car: {Brand} {Model}"; 

    }
    public sealed class Truck : Vehicle
    {
        public Truck(in string brand, in string model, in DateOnly productionDate, in DateTime lastInspectionTime) : base(brand, model, productionDate, lastInspectionTime) { }
        public override string InspectionStatus()
        {
            if (base.ProductionDate.Year > 1 && base.LastInspection.Year > 1) return $"{this.GetType().Name} NEED inspection ASAP and is NOT allowed to drive!";
            return $"{this.GetType().Name} Is good to drive";
        }
        public override string DisplayInfo() => $"Truck: {Brand} {Model}";
    }
}