// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

StreamReader sr = null;

sr.ReadLine();

await foreach (var item in GetZahlen())
{
    Console.WriteLine(item);
}

async IAsyncEnumerable<int> GetZahlen()
{
    //var liste = new[] { 1, 2, 3, 4 };
    //return liste;
    yield return 1;
    yield return 2;
    yield return 3;
    yield return 4;
}

