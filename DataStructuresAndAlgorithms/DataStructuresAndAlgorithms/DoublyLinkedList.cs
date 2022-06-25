using System.Text;

public class DoublyLinkedList
{
  public DoublyLinkedList(int[] numbers)
  {
    for (var i = 0; i < numbers.Length; i++)
    {
      this.InsertAtHead(new DoublyLinkedNode(numbers[i]));
    }
  }

  internal DoublyLinkedNode? Head { get; set; }

  public override string ToString()
  {
    var stringBuilder = new StringBuilder();
    if (this.Head == null)
    {
      return string.Empty;
    }

    var currentNode = this.Head;
    while (currentNode != null)
    {
      stringBuilder.Append($"{currentNode.Data}");
      currentNode = currentNode.Next;
      if (currentNode != null)
      {
        stringBuilder.Append(',');
      }
    }
    return stringBuilder.ToString();
  }

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

  public void InsertionSort()
  {
    if (this.Head == null || this.Head.Next == null)
    {
      return;
    }

    var selectedNode = this.Head.Next;
    while (selectedNode != null)
    {
      var nextNodeToSort = selectedNode.Next;
      var newPreviousNode = selectedNode.Previous;
      while (newPreviousNode != null && selectedNode.Data < newPreviousNode.Data)
      {
        newPreviousNode = newPreviousNode.Previous;
      }

      if (newPreviousNode == selectedNode.Previous)
      {
        selectedNode = nextNodeToSort;
        continue;
      }

      // insert after newPreviosNode
      if (selectedNode.Next != null)
      {
        selectedNode.Next.Previous = selectedNode.Previous;
      }

      if (selectedNode.Previous == null)
      {
        throw new NullReferenceException(nameof(selectedNode.Previous));
      }
      selectedNode.Previous.Next = selectedNode.Next;

      if (newPreviousNode == null)
      {
        selectedNode.Previous = null;
        InsertAtHead(selectedNode);
      }
      else
      {
        if (newPreviousNode.Next == null)
        {
          throw new NullReferenceException(nameof(newPreviousNode.Next));
        }
        newPreviousNode.Next.Previous = selectedNode;
        selectedNode.Next = newPreviousNode.Next;
        newPreviousNode.Next = selectedNode;
        selectedNode.Previous = newPreviousNode;
      }
      selectedNode = nextNodeToSort;
    }
  }
}
