using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaleOfMati.CommandLine
{
    public static class CommandLineHelper
    {
        private const int ConsoleWindowLength = 80;

        public static void PrintWholeWords(string text)
        {
            var words = text.Split(' ');
            var lines = words.Skip(1).Aggregate(words.Take(1).ToList(), (l, w) =>
            {
                if (l.Last().Length + w.Length >= ConsoleWindowLength)
                    l.Add(w);
                else
                    l[l.Count - 1] += " " + w;
                return l;
            });

            foreach (var line in lines)
                LazyPrint(line);
        }

        public static void LazyPrint(string data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                Console.Write(data[i]);
                System.Threading.Thread.Sleep(50);
            }
            Console.WriteLine();
        }

        public static string GetInput(Func<string> getNextPossibleAction, IDictionary<string, string> possibleActions,
            int shownActionId)
        {
            Console.Write(">> ");
            while (true)
            {
                var readKey = Console.ReadKey().Key;

                if (readKey == ConsoleKey.Tab)
                {
                    ClearCurrentConsoleLine();
                    Console.Write(">> ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(getNextPossibleAction.Invoke());
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (readKey == ConsoleKey.Enter)
                {
                    return possibleActions.ElementAt(shownActionId - 1).Key;
                }
            }
        }

        public static void GetAnyInput()
        {
            Console.ReadLine();
        }

        public static void ClearCurrentConsoleLine()
        {
            var currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        public static void PrintLocation(string location)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            PrintWholeWords("[" + location + "]");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
