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
        public IDictionary<string, IStoryAction> PossibleActions { get; set; }
        public IStoryAction ChosenAction { get; set; }

        private const int ConsoleWindowLength = 80;

        public StoryActionBase()
        {
            PossibleActions = new Dictionary<string, IStoryAction>();
        }

        public void InvokeAction()
        {
            PrintWholeWords("["+ PlaceDescription + "]");
            PrintWholeWords(ActionDescription);

            while(true)
            {
                var input = GetInput().Trim();
                try
                {
                    ChosenAction = PossibleActions[input];
                    break;
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine("Nie wiem, co masz na myśli. Spróbuj jeszcze raz.");
                }
            }

            Console.WriteLine();
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
            return Console.ReadLine();
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
    }
}
