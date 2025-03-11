class Room
{
    static int ID = 0;
    public int coordX;
    public int coordY;
    private bool hasKey { get; set; }

    private bool explored { get; set; } = false;

    public Room(int coordX, int coordY)
    {
        ID++;
        this.coordX = coordX;
        this.coordY = coordY;
    }

    public bool getExplored()
    {
        if (coordX == 0 && coordY == 0)
        {
            return true;
        }

        return explored;
    }

    public void setExplored(bool explored)
    {
        this.explored = explored;
    }

    // concept of fog of war
    // see which room has not been explored
    // set randoms keys to retrieve in each room
    // set a final door to unlock with all keys
}
