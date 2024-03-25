// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

//object dings = new DateTime(2000, 1, 1);
object dings = new string("Hallo");

//old style casting
if (dings != null && dings is DateTime)
{
    DateTime dingsAlsDateTime = (DateTime)dings;
}

//boxing 
DateTime? dingsAlsDateTimeBoxing = dings as DateTime?;
if (dingsAlsDateTimeBoxing != null)
{
    Console.WriteLine(dingsAlsDateTimeBoxing);
}

//pattern matching  'is'
if (dings is DateTime dt)
{
    Console.WriteLine(dt);
}
    





Console.WriteLine("Ende");