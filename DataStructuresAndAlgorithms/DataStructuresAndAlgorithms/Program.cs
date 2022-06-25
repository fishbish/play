class Program
{
  static void Main(string[] args)
  {
    // See https://aka.ms/new-console-template for more information
    // 5,7,2,24,15,6,9,12,1,66
    // 2,3,4,1,5,6,7
    // 1,2,3,4,5,6,7
    // 7,6,5,4,3,2,1
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

