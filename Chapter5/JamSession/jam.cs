namespace CSharp
{
  class MainClass
  {
    public static void Main ()
    {
      Console.WriteLine("Hello World");



      Func<int, int> f = x => x * 2;

      Func<int, int> h = (x) => {
        Console.WriteLine("...");
        return x*2;
      }

      Console.WriteLine(f (3));

      Console.WriteLine(h (3));

      Expression<Func<int, int>> g = x => x * 2;

      Console.WriteLine(g);

      var xs = new[] {1,2,3,4,5}
      var ys = from x in xs
               where x < 4
               select x * 2;

    }
  }
}
