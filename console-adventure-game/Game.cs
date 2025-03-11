class Game
{
    Dictionary<string, int> difficultyMap;
    public List<List<Room>> rooms;
    public Player player;

    public Room currentRoom;

    public Game()
    {
        difficultyMap = new Dictionary<string, int> { { "1", 3 }, { "2", 5 }, { "3", 7 } };
        rooms = new List<List<Room>>();
        player = new Player("Matthieu", 0, 0, this);
        currentRoom = new Room(0, 0);
    }

    public void Start()
    {
        bool gameLoop = true;
        Console.WriteLine("Welcome to my adventure game");
        Console.WriteLine(
            "How difficult should the game be ? \n 1 - easy (9 rooms) \n 2 - medium (25 rooms) \n 3 - hard (36 rooms) "
        );

        string input = ReadInput();
        while (input != "1" && input != "2" && input != "3")
        {
            Console.WriteLine("Invalid input. Please enter 1, 2, or 3.");
            input = ReadInput();
        }

        GenerateRooms(input);

        while (gameLoop)
        {
            Console.WriteLine(
                "What do you want to? \n - move \n - inventory \n - quit \n - rules "
            );

            string? action = ReadInput();

            switch (action)
            {
                case "move":
                    player.Move(rooms);
                    break;
                case "inventory":
                    // player.getInventory()
                    break;
                case "rules":
                    ShowRules();
                    break;
                case "quit":
                    gameLoop = false;
                    break;
                default:
                    Console.WriteLine("Wrong input please try again");
                    break;
            }
        }
    }

    private void ShowRules()
    {
        Console.WriteLine("GAME RULES:");
        Console.WriteLine("1. Difficulty levels determine the number of rooms:");
        Console.WriteLine("   - Easy: 9 rooms");
        Console.WriteLine("   - Medium: 25 rooms");
        Console.WriteLine("   - Hard: 49 rooms (or as defined)");
        Console.WriteLine("2. Use text commands (up, down, left, right) to move between rooms.");
        Console.WriteLine(
            "3. Some rooms hide keys. You only learn a room has a key when you enter it."
        );
        Console.WriteLine("4. Your goal is to collect all keys as fast as possible.");
        Console.WriteLine();
    }

    private void GenerateRooms(string difficulty)
    {
        int size = difficultyMap.TryGetValue(difficulty, out int value) ? value : 3;
        int centerIndex = size - 1 / 2;
        for (int i = -centerIndex; i < centerIndex; i++)
        {
            rooms.Add(new List<Room>());
            for (int j = -centerIndex; j < centerIndex; j++)
            {
                rooms[i].Add(new Room(i, j));
            }
        }
    }

    public void setCurrentRoom(Player player)
    {
        int lengthX = rooms.Count;
        for (int i = 0; i < lengthX; i++)
        {
            int lengthY = rooms[i].Count;
            for (int j = 0; j < lengthY; j++)
            {
                if (rooms[i][j].coordX == player.coordX && rooms[i][j].coordY == player.coordY)
                {
                    currentRoom = rooms[i][j];
                }
            }
        }
    }

    public void ShowRooms(Player playerInstance)
    {
        int size = rooms.Count;
        int centerIndex = size - 1 / 2;
        Console.WriteLine("here is you current position\n");
        for (int i = -centerIndex; i < centerIndex; i++)
        {
            for (int j = centerIndex; j < centerIndex; j++)
            {
                rooms[i][j].ShowRoom(playerInstance);
            }
        }
    }

    public static string ReadInput()
    {
        return Console.ReadLine()?.ToLower() ?? "Unknown";
    }
}
