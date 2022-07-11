using DataStructuresAndAlgorithms;

class Program
{
  static void Main(string[] args)
  {
    TowerOfHanoi.Move(4, 'a', 'c', 'b');
    Console.WriteLine("Enter Numbers:");
    var input = Console.ReadLine();
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

