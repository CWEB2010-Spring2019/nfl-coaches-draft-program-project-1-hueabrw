using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace project1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = JsonConvert.DeserializeObject<List<Player>>(File.ReadAllText(@"C:\code\Advanced Programming\Assignments\Project1\nfl-coaches-draft-program-project-1-hueabrw\project1\players.json"));
    
            Display display = new Display(players);
            display.run();
        }


        class Display
        {
            List<Player> players;
            static List<string> positions = new List<string>(new string[] { "Quarterback", "Running Back", "Wide-Receiver", "Defensive Lineman", "Defensive-Back", "Tight End", "Line-Back", "Offensive Teackle" });
            int highlight;
            ConsoleKey userKey;
            public Display(List<Player> _players)
            {
                players = _players;
            }
            public void run()
            {
                highlight = 0;

                userKey = new ConsoleKey();
                while (userKey != ConsoleKey.Escape)
                {
                    
                    DisplayChart();
                    NavigateChart();

                    Console.Clear();
                }
            }

            
            private void Draft(Player chosenPlayer)
            {
                throw new NotImplementedException();
            }

            private void NavigateChart()
            {
                userKey = Console.ReadKey().Key;

                if (userKey == ConsoleKey.DownArrow)
                {
                    int original = highlight;
                    highlight += 5;
                    try
                    {
                        while (getPlayer(highlight).isSelected())
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
                        while (getPlayer(highlight).isSelected())
                        {
                            highlight -= 5;
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
                        while (getPlayer(highlight).isSelected())
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
                        while (getPlayer(highlight).isSelected())
                        {
                            highlight--;
                        }
                    }
                    catch
                    {
                        highlight = original;
                    }
                }
                else if (userKey == ConsoleKey.Enter)
                {
                    Player selectedPlayer = getPlayer(highlight);
                    selectedPlayer.selected = true;
                }

                if (highlight < 0)
                {
                    highlight = 0;
                }
                else if (highlight > players.Count)
                {
                    highlight = players.Count;
                }
                
            }
            private void DisplayChart()
            {
                
                foreach (string position in positions)
                {
                    for (int i = positions.IndexOf(position) * 5; i < 5 + (5 * positions.IndexOf(position)); i++)
                    {
                        print(players[i], players[i].name);
                    }
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine();
                    for (int i = positions.IndexOf(position) * 5; i < 5 + (5 * positions.IndexOf(position)); i++)
                    {
                        print(players[i], players[i].school);
                    }
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine();
                    for (int i = positions.IndexOf(position) * 5; i < 5 + (5 * positions.IndexOf(position)); i++)
                    {
                        print(players[i], (players[i].salary).ToString("c"));
                    }
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine();
                }
            }
            private void print(Player player, string data)
            {
                if (highlight == players.IndexOf(player))
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                }
                else if (player.isSelected())
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.Write(data.PadRight(20));
            }

            public Player getPlayer(int playerNum)
            {
                foreach (Player player in players)
                {
                    if (players.IndexOf(player) == playerNum)
                    {
                        return player;
                    }
                }
                return null;
            }
            
        }
        class Manager
        {
            double budget;
            List<Player> draftedPlayers = new List<Player>();
            int picks;

            public Manager(double _budget, int _picks)
            {
                budget = _budget;
                picks = _picks;
            }
        }
        class Player
        {
            public string name { get; set; }
            public int salary { get; set; }
            public string school { get; set; }
            public string position { get; set; }
            public int rank { get; set; }
            public bool selected{ get; set; }

            public Player(string _name, int _salary, string _school, string _position, int _rank)
            {
                name = _name;
                salary = _salary;
                school = _school;
                position = _position;
                rank = _rank;
                selected = false;
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
            public bool isSelected()
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
