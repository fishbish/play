namespace DataStructuresAndAlgorithms
{
  internal class TowerOfHanoi
  {
    internal static void Move(int n, char from, char to, char intermediate, ref int steps)
    {
      if (intermediate == to || n == 1)
      {
        Console.WriteLine($"Moving {n} from {from} to {to}");
        steps++;
        return;
      }
      else 
      {
        Move(n-1, from, intermediate, to, ref steps);
        Move(n, from, to, to, ref steps);
        Move(n-1, intermediate, to, from, ref steps);
        return;
      }
    }
  }
}
