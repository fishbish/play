internal class DoublyLinkedNode
{
  public DoublyLinkedNode(int data)
  {
    this.Data = data;
  }

  internal int Data { get; set; }

  internal DoublyLinkedNode? Next { get; set; }

  internal DoublyLinkedNode? Previous { get; set; }

  public override string ToString()
  {
    var previousString = $"Prev:{this.Previous?.Data.ToString() ?? "null"}";
    var nextString = $"Next:{this.Next?.Data.ToString() ?? "null"}";
    return $"{previousString}, Data:{this.Data}, {nextString}";
  }
}
