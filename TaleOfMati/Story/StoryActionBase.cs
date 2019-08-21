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

        public StoryActionBase()
        {
            PossibleActions = new Dictionary<string, IStoryAction>();
        }

        public void InvokeAction()
        {
            LazyPrint("["+ PlaceDescription + "]");
            LazyPrint(ActionDescription);

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
    }
}
