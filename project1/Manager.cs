using System;
using System.Collections.Generic;
using System.Text;

namespace project1
{
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
            if (player.selected)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nThis player has already been selected");
                System.Threading.Thread.Sleep(1000);
                Console.BackgroundColor = ConsoleColor.Black;
                return false;
            }
            else if (player.salary < budget)
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
            foreach (Player player in draftedPlayers)
            {
                players += (player.name + ", ");
            }
            return players;

        }
    }
}
