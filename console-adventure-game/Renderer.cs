using System;
using System.Collections.Generic;

class Renderer
{
    private static int cellWidth = 12; // Fixed cell width for alignment

    public static void ShowRooms(List<List<Room>> rooms, Player player)
    {
        int size = rooms.Count;
        Console.WriteLine("\nHere is your current position:\n");

        // Print top border
        PrintTopBorder(size);

        for (int i = 0; i < size; i++)
        {
            PrintRoomRow(rooms, player, i);

            // Print row separators or bottom border
            if (i < size - 1)
            {
                PrintRowSeparator(size);
            }
            else
            {
                PrintBottomBorder(size);
            }
        }
    }

    private static void PrintRoomRow(List<List<Room>> rooms, Player player, int row)
    {
        Console.Write("│");
        for (int j = 0; j < rooms[row].Count; j++)
        {
            string content = "";
            Room currentRoom = rooms[row][j];

            if (currentRoom.coordX == player.coordX && currentRoom.coordY == player.coordY)
            {
                content = "🧍";
            }
            else if (currentRoom.getExplored())
            {
                if (currentRoom.getHasKey())
                {
                    content = "🔑";
                }
                else
                {
                    content = "";
                }
            }
            else
            {
                content = "????";
            }

            int paddingTotal = cellWidth - content.Length;
            int padLeft = paddingTotal / 2;
            int padRight = paddingTotal - padLeft;

            Console.Write(new string(' ', padLeft) + content + new string(' ', padRight) + "│");
        }
        Console.WriteLine();
    }

    private static void PrintTopBorder(int size)
    {
        Console.Write("┌");
        for (int j = 0; j < size; j++)
        {
            Console.Write(new string('─', cellWidth));
            // print top row or right corner
            Console.Write(j < size - 1 ? "┬" : "┐");
        }
        Console.WriteLine();
    }

    private static void PrintRowSeparator(int size)
    {
        Console.Write("├");
        for (int j = 0; j < size; j++)
        {
            Console.Write(new string('─', cellWidth));
            Console.Write(j < size - 1 ? "┼" : "┤");
        }
        Console.WriteLine();
    }

    private static void PrintBottomBorder(int size)
    {
        Console.Write("└");
        for (int j = 0; j < size; j++)
        {
            Console.Write(new string('─', cellWidth));
            Console.Write(j < size - 1 ? "┴" : "┘");
        }
        Console.WriteLine();
    }
}
