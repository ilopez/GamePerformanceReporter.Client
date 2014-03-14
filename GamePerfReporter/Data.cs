using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePerfReporter
{
    class Data
    {
        internal static Games getGameList()
        {
            List<Game> games = new List<Game>();



            games.Add(new Game("PlanetSide 2", "PlanetSide2.exe", new List<String>() { "/UserOptions.ini", "/Graphics.ini" }));
            games.Add(new Game("Star Wars: Empire At War - Forces of Corruption", "swfoc.exe", new List<String>()));
            games.Add(new Game("Minecraft", "javaw.exe", new List<String>()));

            return new Games(games);

        }
        
    }
   

}
