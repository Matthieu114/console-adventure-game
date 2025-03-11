class Game
{
    Dictionary<string, int> difficultyMap;
    public List<List<Room>> rooms;
    public Player player;

    public Room currentRoom;

    public Game()
    {
        difficultyMap = new Dictionary<string, int>
        {
            { "1", 3 },
            { "2", 5 },
            { "3", 7 },
        };
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
                "\nWhat do you want to? \n 1 - move \n 2 - inventory \n 3 - show position \n 4 - rules \n 5 - quit \n"
            );

            string? action = ReadInput();

            switch (action)
            {
                case "move":
                case "1":
                    player.Move(rooms);
                    break;
                case "2":
                case "inventory":
                    // player.getInventory()
                    break;
                case "3":
                case "show position":
                    ShowRooms();
                    break;
                case "4":
                case "rules":
                    ShowRules();
                    break;
                case "5":
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
        int centerIndex = (size - 1) / 2;
        for (int i = 0; i < size; i++)
        {
            rooms.Add(new List<Room>());
            for (int j = 0; j < size; j++)
            {
                // we substract center index so that 0 becomes the middle coordinates
                rooms[i].Add(new Room(i - centerIndex, j - centerIndex));
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
                    currentRoom.setExplored(true);
                }
            }
        }
    }

    public void ShowRooms()
    {
        Renderer.ShowRooms(rooms, player);
    }

    public static string ReadInput()
    {
        return Console.ReadLine()?.ToLower() ?? "Unknown";
    }
}
