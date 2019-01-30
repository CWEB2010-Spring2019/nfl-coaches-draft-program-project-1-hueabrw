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
            Console.SetWindowSize(150,45);
            List<Player> players = JsonConvert.DeserializeObject<List<Player>>(File.ReadAllText(@"C:\code\Advanced Programming\Assignments\Project1\nfl-coaches-draft-program-project-1-hueabrw\project1\players.json"));
    
            Display display = new Display(players);
            display.run();
        }


        class Display
        {
            List<Player> players;
            Manager user;
            static List<string> positions = new List<string>(new string[] { "Quarterback", "Running Back", "Wide-Receiver", "Defensive Lineman", "Defensive-Back", "Tight End", "Line-Back", "Offensive Teackle" });
            int highlight;
            ConsoleKey userKey;
            public Display(List<Player> _players)
            {
                user = new Manager();
                players = _players;
            }
            public void run()
            {
                highlight = 0;

                userKey = new ConsoleKey();
                while (userKey != ConsoleKey.Escape && user.picks < 5)
                {
                    
                    DisplayChart();
                    NavigateChart();

                    Console.Clear();
                }
                DisplayResults();

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }

            private void DisplayResults()
            {
                int type = 0;
                int highRank = 0;
                Console.Write("Your pick:".PadRight(20));
                for(int i = 0; i < 3; i++)
                {
                    if(type != 0)
                    {
                        Console.Write("".PadRight(20));
                    }
                    foreach(Player player in user.draftedPlayers)
                    {
                        printPlayerInfo(player, type);
                    }
                    Console.WriteLine();
                    type++;
                }
                foreach(Player player in user.draftedPlayers)
                {
                    if(player.rank <= 3)
                    {
                        highRank++;
                    }
                }
                int moneySpent = (95000000 - user.budget);
                Console.WriteLine("The total you spent this draft: "+ moneySpent.ToString("c"));
                if(moneySpent < 65000000 && highRank >= 3)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("This was a cost effective draft!");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }

            private void printPlayerInfo(Player player, int data)
            {
                if(data == 0)
                {
                    Console.Write(player.name.PadRight(20));
                }else if (data == 2)
                {
                    Console.Write(player.salary.ToString("c").PadRight(20));
                }else if (data == 1)
                {
                    Console.Write(player.school.PadRight(20));
                }
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
                    if (user.draftPlayer(selectedPlayer))
                    {
                        selectedPlayer.selected = true;
                    }
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
                Console.WriteLine("Position".PadRight(20)+ "The Best".PadRight(20)+ "2nd Best".PadRight(20)+ "3rd Best".PadRight(20)+ "4th Best".PadRight(20)+ "5th Best".PadRight(20)+"\n");
                foreach (string position in positions)
                {
                    Console.Write(position.PadRight(20));
                    for (int i = positions.IndexOf(position) * 5; i < 5 + (5 * positions.IndexOf(position)); i++)
                    {
                        print(players[i], players[i].name);
                    }
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine();
                    Console.Write("".PadRight(20));
                    for (int i = positions.IndexOf(position) * 5; i < 5 + (5 * positions.IndexOf(position)); i++)
                    {
                        print(players[i], players[i].school);
                    }
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine();
                    Console.Write("".PadRight(20));
                    for (int i = positions.IndexOf(position) * 5; i < 5 + (5 * positions.IndexOf(position)); i++)
                    {
                        print(players[i], (players[i].salary).ToString("c"));
                    }
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine();
                    Console.WriteLine();
                }

                Console.WriteLine("\nHighlight desired pick, Then press ENTER to draft player");
                Console.WriteLine("\nPress ESCAPE to finish your draft");
                Console.WriteLine("\nYour current budget: " + user.budget.ToString("c"));
                if (user.draftedPlayers.Count > 0)
                {
                    Console.WriteLine("Your current draft: " + user.getDraftedPlayers());
                }
            }
            private void print(Player player, string data)
            {
                
                if (player.isSelected())
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                }else if (highlight == players.IndexOf(player))
                {
                    Console.BackgroundColor = ConsoleColor.Green;
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
            public int budget { get; set; }
            public List<Player> draftedPlayers { get; set; }
            public int picks { get; set; }

            public Manager()
            {
                budget = 95000000;
                draftedPlayers = new List<Player>();
                picks = 0;
            }

            public bool draftPlayer(Player player)
            {
                if(player.salary < budget)
                {
                    picks++;
                    budget -= player.salary;
                    draftedPlayers.Add(player);
                    return true;
                }
                else
                {
                    Console.WriteLine();
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("This draft pick exceeds your budget");
                    System.Threading.Thread.Sleep(1000);
                    Console.BackgroundColor = ConsoleColor.Black;
                    return false;
                }
            }

            internal string getDraftedPlayers()
            {
                string players = "";
                foreach(Player player in draftedPlayers)
                {
                    players += (player.name + ", ");
                }
                return players;

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
