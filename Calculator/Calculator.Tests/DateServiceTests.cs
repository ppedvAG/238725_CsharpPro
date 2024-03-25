using Microsoft.QualityTools.Testing.Fakes;

namespace Calculator.Tests
{
    public class DateServiceTests
    {
        [Fact]
        public void IsWeekend_all_weekdays()
        {
            var ds = new DateService();

            using var context = ShimsContext.Create();

            System.Fakes.ShimDateTime.NowGet = () => new DateTime(2024, 3, 25);
            Assert.False(ds.IsWeekend());
            System.Fakes.ShimDateTime.NowGet = () => new DateTime(2024, 3, 26);
            Assert.False(ds.IsWeekend());
            System.Fakes.ShimDateTime.NowGet = () => new DateTime(2024, 3, 27);
            Assert.False(ds.IsWeekend());
            System.Fakes.ShimDateTime.NowGet = () => new DateTime(2024, 3, 28);
            Assert.False(ds.IsWeekend());
            System.Fakes.ShimDateTime.NowGet = () => new DateTime(2024, 3, 29);
            Assert.False(ds.IsWeekend());
            System.Fakes.ShimDateTime.NowGet = () => new DateTime(2024, 3, 30);
            Assert.True(ds.IsWeekend());
            System.Fakes.ShimDateTime.NowGet = () => new DateTime(2024, 3, 31);
            Assert.True(ds.IsWeekend());
        }

        [Fact]
        public void IsDummeDateiDa_yo()
        {
            using (var context = ShimsContext.Create())
            {
                System.IO.Fakes.ShimFile.ExistsString = (path) => true;

                var ds = new DateService();

                Assert.True(ds.IsDummeDateiDa());
            }
        }
    }
}
