using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaleOfMati.CommandLine
{
    public static class CommandLineHelper
    {
        private const string InputPrefix = ">> ";

        public static void PrintWholeWords(string text, bool breakLineAfterPrint = true)
        {
            var words = text.Split(' ');
            var lines = words.Skip(1).Aggregate(words.Take(1).ToList(), (l, w) =>
            {
                if (l.Last().Length + w.Length >= ConsoleConstants.ConsoleWidth - 5)
                    l.Add(w);
                else
                    l[l.Count - 1] += " " + w;
                return l;
            });

            foreach (var line in lines)
                LazyPrint(line, breakLineAfterPrint);
        }

        public static void LazyPrint(string data, bool breakLineAfterPrint)
        {
            for (int i = 0; i < data.Length; i++)
            {
                Console.Write(data[i]);
                System.Threading.Thread.Sleep(50);
            }

            if(breakLineAfterPrint)
                Console.WriteLine();
        }

        public static string GetInput(Func<string> getNextPossibleInput, IDictionary<string, string> possibleActions,
            ref int shownActionId)
        {
            Console.Write(InputPrefix);
            while (true)
            {
                var readKey = Console.ReadKey().Key;

                if (readKey == ConsoleKey.Tab)
                {
                    ToggleInput(getNextPossibleInput);
                }
                else if (readKey == ConsoleKey.Enter)
                {
                    try
                    {
                        return possibleActions.ElementAt(shownActionId - 1).Key;
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        ToggleInput(getNextPossibleInput);
                    }
                }
            }
        }

        private static void ToggleInput(Func<string> getNextPossibleInput)
        {
            ClearCurrentConsoleLine();
            Console.Write(InputPrefix);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(getNextPossibleInput.Invoke());
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void GetAnyInput()
        {
            Console.Write(InputPrefix);
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
            Console.WriteLine(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Green;
            PrintWholeWords("[" + location + "]");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void PrintActionDescription(string actionDescription, IDictionary<string, string> possibleActions)
        {
            PrintWholeWords(actionDescription, possibleActions.Keys.Count > 1);
        }
    }
}
