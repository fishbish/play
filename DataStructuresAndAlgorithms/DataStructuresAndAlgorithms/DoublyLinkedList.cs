namespace DataStructuresAndAlgorithms
{
  internal class DoublyLinkedList
  {
    internal DoublyLinkedNode? Head { get; set; }

    internal int Length()
    {
      if (this.Head == null)
      {
        return 0;
      }

      var currentNode = this.Head;
      var count = 1;
      while (currentNode != null)
      {
        count++;
        currentNode = currentNode.Next;
      }
      return count;
    }

    internal void InsertAtHead(DoublyLinkedNode node)
    {
      if (this.Head != null)
      {
        this.Head.Previous = node;
        node.Next = this.Head;
      }
      this.Head = node;
    }
  }
}
