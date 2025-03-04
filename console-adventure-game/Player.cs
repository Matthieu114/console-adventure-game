class Player
{
    public string name { get; }
    public int coordX { get; set; }
    public int coordY { get; set; }

    public Player(string name, int coordX, int coordY)
    {
        this.name = name;
        this.coordX = coordX;
        this.coordY = coordY;
    }

    public void Move(string direction, List<List<Room>> rooms)
    {
        switch (direction)
        {
            case "left":
                break;
            case "right":
                break;
            case "up":
                break;
            case "down":
                break;
            default:
                break;
        }
    }

    public bool CanMoveInDirection(List<List<Room>> rooms)
    {
        return false;
    }

    /*
    Matrix of rooms
    check

    x,y coords
    can move up up x -1 > 0
    can move down x+ 1 < size

*/
}
