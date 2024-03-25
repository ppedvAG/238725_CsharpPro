namespace Calculator
{
    public class DateService
    {

        public bool IsWeekend()
        {
            return DateTime.Now.DayOfWeek == DayOfWeek.Sunday ||
                   DateTime.Now.DayOfWeek == DayOfWeek.Saturday;
        }


        public bool IsDummeDateiDa()
        {
            return File.Exists("l:\\dateien\\ekjwfn.ewkjfn");
        }

        //korrekt: 
        //public bool IsWeekend(DateTime dt)
        //{
        //    return dt.DayOfWeek == DayOfWeek.Sunday ||
        //           dt.DayOfWeek == DayOfWeek.Saturday;
        //}

    }
}
