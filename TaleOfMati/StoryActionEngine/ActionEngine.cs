using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleOfMati.Story;
using TaleOfMati.Story.StoryActions;

namespace TaleOfMati.StoryActionEngine
{
    public class ActionEngine
    {
        private IStoryAction FirstAction;
        private IStoryAction CurrentAction;

        public ActionEngine()
        {
            FirstAction = new Start();
            CurrentAction = FirstAction;
        }

        public void RunStory()
        {
            while (!(CurrentAction is Stop))
            {
                CurrentAction.InvokeAction();
                CurrentAction = CurrentAction.ChosenAction;
            }
        }
    }
}
