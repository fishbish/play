namespace DataStructuresAndAlgorithms
{
  internal class TowerOfHanoi
  {
    internal static void Move(int n, char from, char to, char intermediate)
    {
      if (intermediate == to || n == 1)
      {
        Console.WriteLine($"Moving {n} from {from} to {to}");
        return;
      }
      else
      {
        Move(n-1, from, intermediate, to);
        Move(n, from, to, to);
        Move(n-1, intermediate, to, from);
        return;
      }
    }
  }
}
