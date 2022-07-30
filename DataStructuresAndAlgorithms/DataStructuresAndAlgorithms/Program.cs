using DataStructuresAndAlgorithms;

class Program
{
  static void Main(string[] args)
  {
    while (1==1)
    {
      Console.WriteLine("Input:");
      RunHashTable(Console.ReadLine());
    }
  }

  private static void RunHashTable(string input)
  {
    var hashTable = new HashTable(input.Length);
    for (int i = 0; i < input.Length; i++)
    {
      hashTable.InsertNode(new Record() { Key = input[i], Value = input[i] });
    }

    while (1 == 1)
    {
      Console.WriteLine("Delete:");
      hashTable.DeleteNode(Console.ReadLine()[0]);
      Console.WriteLine("Get:");
      var record = hashTable.GetNode(Console.ReadLine()[0]);
      Console.WriteLine(record.Value);
    }
  }

  private static void RunTOH(string input)
  {
    var steps = 0;
    TowerOfHanoi.Move(int.Parse(input), 'a', 'c', 'b', ref steps);
    Console.WriteLine(steps);
  }

  private static void RunSort(string input)
  {
    var numbersText = input.Split(',');
    var numbers = new int[numbersText.Length];
    for (var i = 0; i < numbersText.Length; i++)
    {
      numbers[i] = int.Parse(numbersText[i]);
    }

    var list = new DoublyLinkedList(numbers);
    Console.WriteLine(string.Join(',', list.ToString()));
    list.InsertionSort();
    Console.WriteLine(string.Join(',', list.ToString()));

    //Sort.SelectionSort(numbers);
    //Console.WriteLine(string.Join(',', numbers));
  }
}

