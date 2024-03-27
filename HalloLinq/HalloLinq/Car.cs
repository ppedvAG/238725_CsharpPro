namespace HalloLinq
{
    public class Car
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int KW { get; set; }
        public DateTime BuildDate { get; set; }

        public override bool Equals(object? obj)
        {
            return this.Id == ((Car)obj).Id;
        }

        
        public static bool operator ==(Car a, Car b)
        {
            return a.Id == b.Id;
        }
        public static bool operator !=(Car a, Car b)
        {
            return a.Id != b.Id;
        }

        public static implicit operator Car(Button btn)
        {
            return new Car
            {
                Id = btn.BackColor.R,
                Model = btn.Text,
            };
        }

    }
}
