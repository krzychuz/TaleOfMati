using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleOfMati.CommandLine;

namespace TaleOfMati.Story
{
    public class StoryActionBase : IStoryAction
    {
        public string PlaceDescription { get; set; }
        public string ActionDescription { get; set; }
        public IDictionary<string, string> PossibleActions { get; set; }
        public string ChosenActionId { get; set; }
        public string Id { get; set; }

        private int _shownActionId = 0;

        public StoryActionBase()
        {
            PossibleActions = new Dictionary<string, string>();
        }

        public void InvokeAction()
        {
            CommandLineHelper.PrintLocation(PlaceDescription);
            CommandLineHelper.PrintWholeWords(ActionDescription);

            while(true)
            {
                if (PossibleActions.Count == 1)
                {
                    HandleAutoAction();
                    break;
                }
                else if(PossibleActions.Count == 0)
                {
                    HandleGameOver();
                }
                else
                {
                    HandleActionWithInput();
                    break;
                }
            }

            Console.WriteLine(Environment.NewLine);
        }

        private void HandleActionWithInput()
        {
            var input = CommandLineHelper.GetInput(GetNextPossibleAction, PossibleActions, _shownActionId);
            try
            {
                ChosenActionId = PossibleActions[input];
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Nie wiem, co masz na myśli. Spróbuj jeszcze raz.");
            }
        }

        private void HandleAutoAction()
        {
            var actionToDo = PossibleActions.Keys.First();

            switch (actionToDo)
            {
                case "AUTO":
                    ChosenActionId = PossibleActions["AUTO"];
                    break;
                case "ANY":
                    ChosenActionId = PossibleActions["ANY"];
                    CommandLineHelper.GetAnyInput();
                    break;
                default:
                    ChosenActionId = PossibleActions[actionToDo];
                    break;
            }
        }

        private void HandleGameOver()
        {
            Console.WriteLine("GAME OVER!");
            Console.ReadLine();
            Environment.Exit(0);
        }

        private string GetNextPossibleAction()
        {
            if (PossibleActions.Count == _shownActionId)
                _shownActionId = 0;

            var actionToReturn = PossibleActions.ElementAt(_shownActionId).Key;
            _shownActionId++;
            return actionToReturn;
        }
    }
}
