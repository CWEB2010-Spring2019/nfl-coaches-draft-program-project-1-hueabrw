using System;

namespace project1
{
    class Program
    {
        static void Main(string[] args)
        {
            Player[,] players = { { new Player(0,"Joe",1,"f","q",1), new Player(1, "Bob", 1, "f", "q", 1) , new Player(2, "Henry", 1, "f", "q", 1) , new Player(3, "Fahd", 1, "f", "q", 1) , new Player(4, "Carl", 1, "f", "q", 1)} ,
                                   { new Player(5,"Al",1,"f","q",1), new Player(6, "Ben", 1, "f", "q", 1) , new Player(7, "Rob", 1, "f", "q", 1) , new Player(8, "Ken", 1, "f", "q", 1) , new Player(9, "Nate", 1, "f", "q", 1)} };
            Display display = new Display(players);
            display.run();
        }
        class Display
        {
            Player[,] players;
            public Display(Player[,] _players)
            {
                players = _players;
            }
            public void run()
            {
                int highlight = 0;

                ConsoleKey userKey = new ConsoleKey();
                while (userKey != ConsoleKey.Escape)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            if (highlight == players[i, j].getArrayPosition())
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                            }
                            else if(players[i,j].getSelected())
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            Console.Write(players[i, j].getName() + "\t");

                        }
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine();
                    }
                    userKey = Console.ReadKey().Key;

                    if (userKey == ConsoleKey.DownArrow)
                    {
                        int original = highlight;
                        highlight += 5;
                        try
                        {
                            while (getPlayer(highlight).getSelected())
                            {
                                highlight += 5;
                            }
                        }
                        catch
                        {
                            highlight = original;
                        }
                    }
                    else if (userKey == ConsoleKey.UpArrow)
                    {
                        int original = highlight;
                        highlight -= 5;
                        try
                        {
                            while (getPlayer(highlight).getSelected())
                            {
                                highlight -=5;
                            }
                        }
                        catch
                        {
                            highlight = original;
                        }
                    }
                    else if (userKey == ConsoleKey.RightArrow)
                    {
                        int original = highlight;
                        highlight++;
                        try
                        {
                            while (getPlayer(highlight).getSelected())
                            {
                                highlight++;
                            }
                        }
                        catch
                        {
                            highlight = original;
                        }
                    }
                    else if (userKey == ConsoleKey.LeftArrow)
                    {
                        int original = highlight;
                        highlight--;
                        try
                        {
                            while (getPlayer(highlight).getSelected())
                            {
                                highlight--;
                            }
                        }
                        catch
                        {
                            highlight = original;
                        }
                    }
                    else if(userKey == ConsoleKey.Enter)
                    {
                        getPlayer(highlight).selectPlayer();
                    }

                    if (highlight < 0)
                    {
                        highlight = 0;
                    }
                    else if (highlight > 9)
                    {
                        highlight = 9;
                    }

                    Console.Clear();
                }
            }
            public Player getPlayer(int playerNum)
            {
                foreach (Player player in players)
                {
                    if (player.getArrayPosition() == playerNum)
                    {
                        return player;
                    }
                }
                return null;
            }
            
        }
        class Player
        {
            int arrayPosition;
            string name;
            int salary;
            string school;
            string position;
            int rank;
            bool selected;

            public Player(int _arrayPosition, string _name, int _salary, string _school, string _position, int _rank)
            {
                arrayPosition = _arrayPosition;
                name = _name;
                salary = _salary;
                school = _school;
                position = _position;
                rank = _rank;
                selected = false;
            }
            public int getArrayPosition()
            {
                return arrayPosition;
            }
            public string getName()
            {
                return name;
            }
            public string getPosition()
            {
                return position;
            }
            public int getSalary()
            {
                return salary;
            }
            public string getSchool()
            {
                return school;
            }
            public int getRank()
            {
                return rank;
            }
            public bool getSelected()
            {
                return selected;
            }
            public void selectPlayer()
            {
                selected = true;
            }
        }
    }
}
