using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

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

    public void ShowRoom(int x, int y, Player player)
    {
        if (coordX == player.coordX && coordY == player.coordY)
        {
            Console.Write("[ > here" + player.coordX + " " + player.coordY + " ]");
        }
        else
        {
            Console.Write("[" + x + " " + y + " ]");
        }
    }
}
