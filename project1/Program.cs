using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace project1
{
    class Program
    {
        //Main Code
        static void Main(string[] args)
        {
            //Setting the console to display all the info
            Console.SetWindowSize(150,45);
            //creates a list of player objects based off a json file.
            List<Player> players = JsonConvert.DeserializeObject<List<Player>>(File.ReadAllText(@"C:\code\Advanced Programming\Assignments\Project1\nfl-coaches-draft-program-project-1-hueabrw\project1\players.json"));
        
            //creates a new Display object passing in the list of players
            Display display = new Display(players);
            //runs the display
            display.run();
        }
    }
}
