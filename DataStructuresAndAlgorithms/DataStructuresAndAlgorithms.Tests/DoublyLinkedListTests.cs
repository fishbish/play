namespace DataStructuresAndAlgorithms.Tests
{
  public class DoublyLinkedListTests
  {
    [Theory]
    [InlineData("5,7,2,24,15,6,9,12,1,66", "1,2,5,6,7,9,12,15,24,66")]
    [InlineData("2,3,4,1,5,6,7", "1,2,3,4,5,6,7")]
    [InlineData("1,2,3,4,5,6,7", "1,2,3,4,5,6,7")]
    [InlineData("7,1,2,3,4,5,6", "1,2,3,4,5,6,7")]
    [InlineData("2,3,4,5,6,7,1", "1,2,3,4,5,6,7")]
    [InlineData("1,7,6,5,4,3,2", "1,2,3,4,5,6,7")]
    [InlineData("7,6,5,4,3,2,1", "1,2,3,4,5,6,7")]
    [InlineData("6,5,4,3,2,1,7", "1,2,3,4,5,6,7")]
    public void Sort(string unsortedString, string sortedString)
    {
      var numbersText = unsortedString.Split(',');
      var numbers = new int[numbersText.Length];
      for (var i = 0; i < numbersText.Length; i++)
      {
        numbers[i] = int.Parse(numbersText[i]);
      }

      var list = new DoublyLinkedList(numbers);
      list.InsertionSort();

      Assert.Equal(list.ToString(), sortedString);
    }
  }
}