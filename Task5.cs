using System.Text;

class Program
{
    static void Main(string[] args)
    {
        TransformToElephant();
        Console.WriteLine("Муха");
        //... custom application code
        var standartOutput = new StreamWriter(Console.OpenStandardOutput());
        standartOutput.AutoFlush = true;
        Console.SetOut(standartOutput);
        Console.OutputEncoding = Encoding.UTF8;
    }

    static void TransformToElephant()
    {
        Console.WriteLine("Слон");
        Console.SetOut(TextWriter.Null);
    }
}
