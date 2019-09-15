using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaleOfMati.CommandLine
{
    public static class AsciiArt
    {
        public static void PrintStartScreen()
        {
            var asciiArt = new[]
            {
                @"                                   _____     _               __  ___  ___      _   _                                   ",
                @"                                  |_   _|   | |             / _| |  \/  |     | | (_)                                  ",
                @"                                    | | __ _| | ___    ___ | |_  | .  . | __ _| |_ _                                   ",
                @"                                    | |/ _` | |/ _ \  / _ \|  _| | |\/| |/ _` | __| |                                  ",
                @"                                    | | (_| | |  __/ | (_) | |   | |  | | (_| | |_| |                                  ",
                @"                                    \_/\__,_|_|\___|  \___/|_|   \_|  |_/\__,_|\__|_|                                  ",
                @"                                                                                                                       ",
                @"                                                        Zasady gry:                                                    ",
                @"                                      * Naciśnij TAB, żeby przeglądać dostępne akcje                                   ",
                @"                                      * Naciśnij ENTER, żeby zatwierdzić wybraną akcję                                 ",
                @"                                                                                                                       ",
                @"                                          Naciśnij ENTER, żeby rozpocząć rozgrywkę!                                    ",
            };

            PrintAsciiArt(asciiArt);

            while(true)
            {
                var key = Console.ReadKey().Key;
                if (key == ConsoleKey.Enter)
                    break;
            }
        }

        public static void PrintGameOverScreen()
        {
            var asciiArt = new[]
            {
                @"                                    _____                                                                              ",
                @"                                   |  __ \                                                                             ",
                @"                                   | |  \/ __ _ _ __ ___   ___    _____   _____ _ __                                   ",
                @"                                   | | __ / _` | '_ ` _ \ / _ \  / _ \ \ / / _ \ '__|                                  ",
                @"                                   | |_\ \ (_| | | | | | |  __/ | (_) \ V /  __/ |                                     ",
                @"                                    \____/\__,_|_| |_| |_|\___|  \___/ \_/ \___|_|                                     ",
                @"                                                                                                                       ",
                @"                                                        Twórcy gry:                                                    ",
                @"                                                      Krzysiek Zabawa                                                  ",
                @"                                                        Magda Kuta                                                     ",
                @"                                                      Magda Tokarska                                                   ",
                @"                                                        Ola Dominas                                                    ",
                @"                                                                                                                       ",
                @"                                                   Urodziny Matiego 2019                                               ",
            };

            PrintAsciiArt(asciiArt);

            while (true)
            {
                var key = Console.ReadKey().Key;
                if (key == ConsoleKey.Enter)
                    Environment.Exit(0);
            }
        }

        private static void PrintAsciiArt(string[] asciiArt)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WindowWidth = ConsoleConstants.ConsoleWidth;
            Console.WriteLine("\n\n");
            foreach (string line in asciiArt)
                Console.WriteLine(line);
            Console.WriteLine("\n\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}
