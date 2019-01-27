using System;

namespace project1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] num = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 10, 11, 12 }, { 13, 14, 15 }, { 16, 17, 18 }, { 19, 20, 21 } };
            int highlight = 1;

            ConsoleKey userKey = new ConsoleKey();
            while (userKey != ConsoleKey.Enter)
            {
                for (int i = 0; i < 7; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (highlight == num[i, j])
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        Console.Write(num[i, j] + "\t");

                    }
                    Console.WriteLine();
                }
                userKey = Console.ReadKey().Key;

                if (userKey == ConsoleKey.DownArrow)
                {
                    highlight += 3;
                }
                else if (userKey == ConsoleKey.UpArrow)
                {
                    highlight -= 3;
                }
                else if (userKey == ConsoleKey.RightArrow)
                {
                    highlight++;
                }
                else if (userKey == ConsoleKey.LeftArrow)
                {
                    highlight--;
                }

                if (highlight < 1)
                {
                    highlight = 1;
                }
                else if (highlight > 21)
                {
                    highlight = 21;
                }

                Console.Clear();
            }
        }
        class Player
        {
            string name;
            int cost;
            string school;
            string position;
            int place;

            public Player(string _name, int _cost, string _school, string _position, int _place)
            {
                name = _name;
                cost = _cost;
                school = _school;
                position = _position;
                place = _place;
            }

            public void printInfo()
            {
                Console.WriteLine();
            }
        }
    }
}
