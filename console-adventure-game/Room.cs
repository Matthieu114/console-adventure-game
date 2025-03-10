class Room
{
    static int ID = 0;
    public int coordX { get; }
    public int coordY { get; }

    public Room(int coordX, int coordY)
    {
        ID++;
        this.coordX = coordX;
        this.coordY = coordY;
    }

    public void ShowRoom(Player player)
    {
        if (coordX == player.coordX && coordY == player.coordY)
        {
            Console.Write("[ " + player.coordX + " > here " + player.coordY + " ]");
        }
        else
        {
            Console.Write("[ " + coordX + " " + coordY + " ]");
        }
    }
}
