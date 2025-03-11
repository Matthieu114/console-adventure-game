class Room
{
    static int ID = 0;
    public int coordX;
    public int coordY;
    private bool hasKey { get; set; } = false;

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

    public bool getHasKey()
    {
        return hasKey;
    }

    public void setHasKey(bool hasKey)
    {
        this.hasKey = hasKey;
    }

    // set difficulty level where start with 3 then 5 then 7
    // set randoms keys to retrieve in each room

    // when player in room with key he gets a prompt on the screen
    // saying there is a key and asking if he wants to pick up

    // set a final door to unlock with all keys
    // final door will be in one room only

    // set monsters in some rooms where if you encounter a monster
    // you roll a dice and if your number is bigger than the monster hp
    // or whatev you lose a key ?
}
