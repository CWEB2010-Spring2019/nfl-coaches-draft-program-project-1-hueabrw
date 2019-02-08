using System;
using System.Collections.Generic;
using System.Text;

namespace project1
{
    //This is the class that runs user interactions
    class Display
    {
        
        //local class vairables
        List<Player> players;
        Manager user;

        static List<string> positions = new List<string>(new string[] { "Quarterback", "Running Back", "Wide-Receiver", "Defensive Lineman", "Defensive-Back", "Tight End", "Line-Back", "Offensive Teackle" });

        int highlight;
        ConsoleKey userKey;

        //Constuctor
        public Display(List<Player> _players)
        {
            user = new Manager();
            players = _players;
            userKey = new ConsoleKey();
            highlight = 0;
        }

        //the main method for user interaction
        public void run()
        {
            WelcomeMessege();
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

        private void WelcomeMessege()
        {
            Console.WriteLine("Welcome to the NFL Draft Simulator!");
            Console.WriteLine("\nPress any key to begin...");
            Console.ReadKey();
            Console.Clear();
        }

        //Displays the results

        private void DisplayResults()
        {
            int type = 0;
            int highRank = 0;
            Console.Write("Your pick:".PadRight(20));
            for (int i = 0; i < 3; i++)
            {
                if (type != 0)
                {
                    Console.Write("".PadRight(20));
                }
                foreach (Player player in user.draftedPlayers)
                {
                    printPlayerInfo(player, type);
                }
                Console.WriteLine();
                type++;
            }

            foreach (Player player in user.draftedPlayers)
            {
                if (player.rank <= 3)
                {
                    highRank++;
                }
            }
            int moneySpent = (95000000 - user.budget);
            Console.WriteLine("The total you spent this draft: " + moneySpent.ToString("c"));
            if (moneySpent < 65000000 && highRank >= 3)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("This was a cost effective draft!");
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        private void printPlayerInfo(Player player, int data)
        {
            if (data == 0)
            {
                Console.Write(player.name.PadRight(20));
            }
            else if (data == 2)
            {
                Console.Write(player.salary.ToString("c").PadRight(20));
            }
            else if (data == 1)
            {
                Console.Write(player.school.PadRight(20));
            }
        }


        private void NavigateChart()
        {
            userKey = Console.ReadKey().Key;

            if (userKey == ConsoleKey.DownArrow || userKey == ConsoleKey.S)
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
            else if (userKey == ConsoleKey.UpArrow || userKey == ConsoleKey.W)
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
            else if (userKey == ConsoleKey.RightArrow || userKey == ConsoleKey.D)
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
            else if (userKey == ConsoleKey.LeftArrow || userKey == ConsoleKey.A)
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
        //Formatting the chart along with additional information
       
        
        private void DisplayChart()
        {
            //Displays Column Heading
            Console.WriteLine("Position".PadRight(20) + "The Best".PadRight(20) + "2nd Best".PadRight(20) + "3rd Best".PadRight(20) + "4th Best".PadRight(20) + "5th Best".PadRight(20) + "\n");
            // For each row, it displays 
            foreach (string position in positions)
            {

                for (int property = 0; property < 3; property++)
                {
                    if (property == 0)
                    {
                        Console.Write(position.PadRight(20));
                    }
                    else
                    {
                        Console.Write("".PadRight(20));
                    }
                    for (int i = positions.IndexOf(position) * 5; i < 5 + (5 * positions.IndexOf(position)); i++)
                    {
                        if (property == 0)
                        {
                            print(players[i], players[i].name);
                        }
                        else if (property == 1)
                        {
                            print(players[i], players[i].school);
                        }
                        else if (property == 2)
                        {
                            print(players[i], (players[i].salary).ToString("c"));
                        }
                    }
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine();
                }
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
            }
            else if (highlight == players.IndexOf(player))
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
}
