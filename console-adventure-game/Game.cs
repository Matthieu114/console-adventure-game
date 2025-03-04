using System;
using System.Numerics;

class Game
{
    Dictionary<string, int> difficultyMap;

    public List<List<Room>> rooms;
    public Player player;

    public Game()
    {
        difficultyMap = new Dictionary<string, int> { { "1", 3 }, { "2", 5 }, { "3", 7 } };
        rooms = new List<List<Room>>();
        player = new Player("Matthieu", 0, 0);
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
        ShowRooms();

        while (gameLoop)
        {
            Console.WriteLine("What do you want to? \n- move \n - inventory \n - quit \n - rules ");

            string? action = ReadInput();

            switch (action)
            {
                case "move":
                    Console.WriteLine("Where Do you want to move ?");
                    string direction = ReadInput();
                    player.Move(direction, rooms);
                    break;
                case "inventory":
                    break;
                case "rules":
                case "quit":
                    gameLoop = false;
                    break;
                default:
                    Console.WriteLine("Wrong input please try again");
                    break;
            }
        }
    }

    private void GenerateRooms(string difficulty)
    {
        int size = difficultyMap.TryGetValue(difficulty, out int value) ? value : 9;

        for (int i = 0; i < size; i++)
        {
            rooms.Add(new List<Room>());
            for (int j = 0; j < size; j++)
            {
                rooms[i].Add(new Room(i, j));
            }
        }
    }

    private void ShowRooms()
    {
        int size = rooms.Count;
        Console.WriteLine("here is you current position");

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                rooms[i][j].ShowRoom(i, j, player);
            }
            Console.WriteLine("");
        }
    }

    public string ReadInput()
    {
        return Console.ReadLine()?.ToLower() ?? "Unknown";
    }
}
