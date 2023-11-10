
var a = new Test()
{
    TestField = 5
};

Console.WriteLine(a.TestField);

public class Test
{
    public int TestField { get; set; }

}