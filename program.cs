namespace CR
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var m = new Matrix("input.txt");
            var c = m.Shift(m);
            Console.WriteLine(m);
            Console.WriteLine(c);
        }
    }
}
