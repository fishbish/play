class Program
{
  static void Main(string[] args)
  {
    // See https://aka.ms/new-console-template for more information
    // 5,7,2,24,15,6,9,12,1,66
    // 2,3,4,1,5,6,7
    // 1,2,3,4,5,6,7
    Console.WriteLine("Enter Numbers:");
    var input = Console.ReadLine();
    var numbersText = input.Split(',');
    var numbers = new int[numbersText.Length];
    for (var i = 0; i < numbersText.Length; i++)
    {
      numbers[i] = int.Parse(numbersText[i]);
    }

    SelectionSort(numbers);
    Console.WriteLine(string.Join(',', numbers));
  }

  private static void BubbleSort(int[] numbers)
  {
    for (var sortedIndex = numbers.Length - 1;  sortedIndex > 0; sortedIndex --)
    {
      for (var i = 0; i < sortedIndex; i++)
      {
        if (numbers[i] > numbers[i + 1])
        {
          var hold = numbers[i];
          numbers[i] = numbers[i + 1];
          numbers[i + 1] = hold;
        }
      }
    }
  }

  private static void InsertionSort(int[] numbers)
  {
    for (var selectedIndex = 1; selectedIndex < numbers.Length; selectedIndex++)
    {
      var selectedNumber = numbers[selectedIndex];
      var insertIndex = selectedIndex - 1;
      while (insertIndex >= 0 && selectedNumber < numbers[insertIndex])
      {
        numbers[insertIndex + 1] = numbers[insertIndex];
        insertIndex--;
      }
      numbers[insertIndex + 1] = selectedNumber;
    }
  }

  private static void SelectionSort(int[] numbers)
  {
    for (var i = 0; i < numbers.Length - 1; i++)
    {
      var minIndex = i;
      for (var j = i+1; j < numbers.Length; j++)
      {
        if (numbers[j] < numbers[minIndex])
        {
          minIndex = j;
        }
      }
      var tmp = numbers[i];
      numbers[i] = numbers[minIndex];
      numbers[minIndex] = tmp;
    }
  }
}

