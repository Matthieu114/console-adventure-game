public enum ItemType
{
    Key,
}

class Item
{
    static int ID = 0;
    public string name { get; set; }
    public ItemType type { get; set; }

    public Item(string name, ItemType type)
    {
        ID++;
        this.name = name;
        this.type = type;
    }

    public override string ToString()
    {
        return name;
    }
}
