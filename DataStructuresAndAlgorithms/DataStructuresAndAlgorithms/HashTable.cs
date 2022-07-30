namespace DataStructuresAndAlgorithms
{
  internal class HashTable
  {
    internal HashTable(int noOfKeys)
    {
      Table = new Record[noOfKeys * 4];
    }

    private Record[] Table { get; set; }

    private int NoOfKeys { get; set; }

    private decimal LoadFactor => this.NoOfKeys / this.Table.Length;

    private int MaxProbeSteps => (int)Math.Ceiling(1 / (1 - this.LoadFactor));

    public void InsertNode(Record node)
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

    public Record? GetNode(object key)
    {
      for (int i = 0; i <= this.MaxProbeSteps; i++)
      {
        var index = this.GetDoubleHash(key, i);
        var node = this.Table[index];
        if (node != null && node.Key.Equals(key))
        {
          return node;
        }
      }
      return null;
    }

    public void DeleteNode (object key)
    {
      for (int i = 0; i <= this.MaxProbeSteps; i++)
      {
        var index = this.GetDoubleHash(key, i);
        var node = this.Table[index];
        if (node != null && node.Key.Equals(key))
        {
          this.Table[index] = null;
          this.NoOfKeys--;
          return;
        }
      }
    }

    private int GetDoubleHash(object key, int probeStep)
    {
      var nodeHash = key.GetHashCode();
      var hashHash = nodeHash.GetHashCode();
      return (nodeHash + probeStep * hashHash) % this.Table.Length;
    }
  }
}
