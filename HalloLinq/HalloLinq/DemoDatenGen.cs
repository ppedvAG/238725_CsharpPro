using Bogus;

namespace HalloLinq
{
    internal class DemoDatenGen
    {
        public IEnumerable<Car> GetDemoCars(int amount = 100)
        {
            var id = 0;
            var faker = new Faker<Car>().UseSeed(7);
            faker.RuleFor(x => x.Id, x => id++);
            faker.RuleFor(x => x.Manufacturer, x => x.Vehicle.Manufacturer());
            faker.RuleFor(x => x.Model, x => x.Vehicle.Model());
            faker.RuleFor(x => x.Type, x => x.Vehicle.Type());
            faker.RuleFor(x => x.KW, x => x.Random.Int(50, 200));
            faker.RuleFor(x => x.BuildDate, x => x.Date.Past(10));

            return faker.Generate(amount);
        }
    }
}
