namespace DataStructuresAndAlgorithms
{
  internal class HashTable
  {
    internal HashTable(int noOfKeys)
    {
      Table = new HashNode?[noOfKeys * 4];
    }

    private HashNode?[] Table { get; set; }

    private int NoOfKeys { get; set; }

    private decimal LoadFactor => this.NoOfKeys / this.Table.Length;

    private int MaxProbeSteps => (int)Math.Ceiling(1 / (1 - this.LoadFactor));

    public void InsertNode(HashNode node)
    {
      var index = -1;
      for (int i = this.MaxProbeSteps; i >= 0; i--)
      {
        var tmpIndex = this.GetDoubleHash(node.Key, i);
        var tmpNode = this.Table[tmpIndex];
        if (tmpNode == null)
        {
          index = tmpIndex;
        }
        else if (tmpNode.Key == node.Key)
        {
          throw new Exception("Key already exists");
        }
      }

      if (index == -1)
      {
        throw new Exception("Hash table is full");
      }

      this.Table[index] = node;
      this.NoOfKeys++;
    }

    public HashNode? GetNode(int key)
    {
      for (int i = 1; i <= this.MaxProbeSteps; i++)
      {
        var index = this.GetDoubleHash(key, i);
        var node = this.Table[index];
        if (node != null && node.Key == key)
        {
          return node;
        }
      }
      return null;
    }

    public void DeleteNode (int key)
    {
      for (int i = 0; i <= this.MaxProbeSteps; i++)
      {
        var index = this.GetDoubleHash(key, i);
        var node = this.Table[index];
        if (node != null && node.Key == key)
        {
          this.Table[index] = null;
          this.NoOfKeys--;
        }
      }
    }

    private int GetDoubleHash(int key, int probeStep)
    {
      var nodeHash = key.GetHashCode();
      var hashHash = nodeHash.GetHashCode();
      return (nodeHash + probeStep * hashHash) % this.Table.Length;
    }
  }
}
