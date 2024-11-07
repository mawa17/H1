namespace src
{
    public static class DatetimeEx
    {
        public static bool HasPassed(this DateTime dt, in uint days) => DateTime.Now.Subtract(dt).TotalDays > days;
    }
    public abstract class Vehicle : IWheels
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime LastInspection { get; set; }
        public int MaxRimSize { get; set; }

        private protected Vehicle(in string brand, in string model, in DateTime productionDate, in DateTime lastInspection)
        {
            this.Brand = brand;
            this.Model = model;
            this.ProductionDate = productionDate;
            this.LastInspection = lastInspection;
        }
        public abstract string InspectionStatus();
        public virtual string DisplayInfo() => $"Brand: {this.Brand}, Model: {this.Model}, Production Date: {this.ProductionDate.ToShortDateString()}";

        public abstract void SetTireType(bool isWinterTire);
        public string GetInterfaceInfo() => (this as IWheels).Info();
    }
    public sealed class Car : Vehicle
    {
        public Car(in string brand, in string model, in DateTime productionDate, in DateTime lastInspectionTime) : base(brand, model, productionDate, lastInspectionTime)
        {
            this.SetTireType(false);
        }
        public override string InspectionStatus()
        {
            if (base.ProductionDate.HasPassed(365 * 4) && base.LastInspection.HasPassed(365 * 2)) return $"{this.GetType().Name} NEED inspection ASAP and is NOT allowed to drive!";
            return $"{this.GetType().Name} Is good to drive";
        }
        public override string DisplayInfo() => $"Car: {base.Brand} {base.Model}";

        public override void SetTireType(bool isWinterTire) => _ = isWinterTire ? base.MaxRimSize = 16 : base.MaxRimSize = 22;
    }
    public sealed class Truck : Vehicle
    {
        public Truck(in string brand, in string model, in DateTime productionDate, in DateTime lastInspectionTime) : base(brand, model, productionDate, lastInspectionTime)
        {
            this.SetTireType(false);
        }
        public override string InspectionStatus()
        {
            if (base.ProductionDate.HasPassed(365) && base.LastInspection.HasPassed(365)) return $"{this.GetType().Name} NEED inspection ASAP and is NOT allowed to drive!";
            return $"{this.GetType().Name} Is good to drive";
        }
        public override string DisplayInfo() => $"Truck: {base.Brand} {base.Model}";

        public override void SetTireType(bool isWinterTire) => _ = isWinterTire ? base.MaxRimSize = 20 : base.MaxRimSize = 17;

    }
}