class Player
{
    public string name { get; }
    public int coordX { get; set; }
    public int coordY { get; set; }
    private Game game;

    // verify data structures -- need to learn all data structures
    // public Dictionary<string, string> inventory;

    public Player(string name, int coordX, int coordY, Game gameInstance)
    {
        this.name = name;
        this.coordX = coordX;
        this.coordY = coordY;
        this.game = gameInstance;
        // this.inventory = new Dictionary<string, string>();
    }

    private void UpdatePlayerCoordinates(int x, int y)
    {
        if (!CanMoveInDirection(x, y))
        {
            Console.WriteLine("\nCan not move player in this direction no room exists\n");
            return;
        }
        coordX += x;
        coordY += y;
        game.setCurrentRoom(this);
        game.ShowRooms();
    }

    public void Move(List<List<Room>> rooms)
    {
        bool loop = true;
        game.ShowRooms();

        while (loop)
        {
            Console.WriteLine(
                "Where Do you want to move ? \n 1 - (left) \n 2 - (right) \n 3 - (up) \n 4 - (down) \n 5 - (stay) \n"
            );
            string direction = Game.ReadInput();
            switch (direction)
            {
                case "1":
                case "left":
                    UpdatePlayerCoordinates(0, -1);
                    break;
                case "2":
                case "right":
                    UpdatePlayerCoordinates(0, 1);
                    break;
                case "up":
                case "3":
                    UpdatePlayerCoordinates(-1, 0);
                    break;
                case "4":
                case "down":
                    UpdatePlayerCoordinates(1, 0);
                    break;
                case "5":
                case "stay":
                    loop = false;
                    break;
                default:
                    Console.WriteLine("Invalid movement input try again");
                    break;
            }
        }
    }

    private bool CanMoveInDirection(int x, int y)
    {
        Room currentRoom = game.currentRoom;
        int roomSize = game.rooms.Count;
        int centerIndex = (roomSize - 1) / 2;
        int maxCoordinates = roomSize - centerIndex;

        if (
            currentRoom.coordX + x < -centerIndex
            || currentRoom.coordY + y < -centerIndex
            || currentRoom.coordX + x > maxCoordinates - 1
            || currentRoom.coordY + y > maxCoordinates - 1
        )
        {
            return false;
        }

        return true;
    }
}
