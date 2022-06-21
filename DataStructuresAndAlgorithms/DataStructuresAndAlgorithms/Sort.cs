class Sort
{
  internal static void BubbleSort(int[] numbers)
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

  internal static void InsertionSort(int[] numbers)
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

  internal static void SelectionSort(int[] numbers)
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

