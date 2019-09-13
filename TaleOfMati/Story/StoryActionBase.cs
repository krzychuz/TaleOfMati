using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaleOfMati.Story
{
    public class StoryActionBase : IStoryAction
    {
        public string PlaceDescription { get; set; }
        public string ActionDescription { get; set; }
        public IDictionary<string, string> PossibleActions { get; set; }
        public string ChosenActionId { get; set; }
        public string Id { get; set; }

        private const int ConsoleWindowLength = 80;
        private int _shownActionId = 0;

        public StoryActionBase()
        {
            PossibleActions = new Dictionary<string, string>();
        }

        public StoryActionBase(string id) : this()
        {
            Id = id;
        }

        public void InvokeAction()
        {
            PrintLocation("["+ PlaceDescription + "]");
            PrintWholeWords(ActionDescription);

            while(true)
            {
                if (PossibleActions.Count == 1)
                {
                    var actionToDo = PossibleActions.Keys.First();

                    switch(actionToDo)
                    {
                        case "AUTO":
                            ChosenActionId = PossibleActions["AUTO"];
                            break;
                        case "ANY":
                            ChosenActionId = PossibleActions["ANY"];
                            GetAnyInput();
                            break;
                        default:
                            ChosenActionId = PossibleActions[actionToDo];
                            break;
                    }

                    break;
                }
                else if(PossibleActions.Count == 0)
                {
                    Console.WriteLine("GAME OVER!");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                else
                {
                    var input = GetInput();
                    try
                    {
                        ChosenActionId = PossibleActions[input];
                        break;
                    }
                    catch (KeyNotFoundException)
                    {
                        Console.WriteLine("Nie wiem, co masz na myśli. Spróbuj jeszcze raz.");
                    }
                }
            }

            Console.WriteLine(Environment.NewLine);
        }

        private void LazyPrint(string data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                Console.Write(data[i]);
                System.Threading.Thread.Sleep(50);
            }
            Console.WriteLine();
        }

        private string GetInput()
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
                    Console.Write(GetNextPossibleAction());
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if(readKey == ConsoleKey.Enter)
                {
                    return PossibleActions.ElementAt(_shownActionId - 1).Key;
                }
            }
        }

        private void GetAnyInput()
        {
            Console.ReadLine();
        }

        private string GetNextPossibleAction()
        {
            if (PossibleActions.Count == _shownActionId)
                _shownActionId = 0;

            var actionToReturn = PossibleActions.ElementAt(_shownActionId).Key;
            _shownActionId++;
            return actionToReturn;
        }

        public static void ClearCurrentConsoleLine()
        {
            var currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        private void PrintWholeWords(string text)
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

            foreach(var line in lines)
                LazyPrint(line);
        }

        private void PrintLocation(string location)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            PrintWholeWords(location);
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}
