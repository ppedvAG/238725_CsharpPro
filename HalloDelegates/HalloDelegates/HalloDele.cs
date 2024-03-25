


namespace HalloDelegates;

delegate void EinfacherDelegate();
delegate void DelegateMitrPara(string text);
delegate long CalcDele(int a, int b);

internal class HalloDele
{
    

    public HalloDele()
    {
        EinfacherDelegate meinDele = EinfacheMethode;
        EinfacherDelegate meinDeleAno = delegate () { Console.WriteLine("Hi"); };
        Action myAction = EinfacheMethode;
        Action myActionAno = () => { Console.WriteLine("Hi"); };
        Action myActionAno2 = () => Console.WriteLine("Hi");

        DelegateMitrPara mitPara = MethodeMitPara;
        DelegateMitrPara mitParaAno = delegate (string msg) { Console.WriteLine(msg); };
        Action<string> myActionMitPara = MethodeMitPara;
        Action<string> mitParaAno2 = (string msg) => { Console.WriteLine(msg); };
        Action<string> mitParaAno3 = (msg) => Console.WriteLine(msg);
        Action<string> mitParaAno4 = msg => Console.WriteLine(msg);

        CalcDele myCalc = Multi;
        CalcDele myCalcAno = delegate (int x, int y) { return x + y; };
        Func<int, int, long> myFuncCalc = Multi;
        CalcDele myCalcAno2 = (int x, int y) => { return x + y; };
        CalcDele myCalcAno3 = (x, y) => { return x + y; };
        CalcDele myCalcAno4 = (x, y) => x + y;

        long rsult = myCalc.Invoke(2, 3);

        List<string> texte = new List<string>();
        texte.Where(x => x.StartsWith("B"));
        texte.Where(Filter);
    }

    private bool Filter(string arg)
    {
        if (arg.StartsWith("B"))
            return true;
        else
            return !true;
    }

    private long Multi(int a, int b)
    {
        return a * b;
    }

    private long Sum(int a, int b)
    {
        return a + b;
    }

    private void MethodeMitPara(string name)
    {
        Console.WriteLine("Hallo" + name);
    }

    void EinfacheMethode()
    {
        Console.WriteLine("Hallo");
    }
}
