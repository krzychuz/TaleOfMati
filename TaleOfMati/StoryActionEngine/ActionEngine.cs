using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleOfMati.CommandLine;
using TaleOfMati.Story;

namespace TaleOfMati.StoryActionEngine
{
    public class ActionEngine : IDisposable
    {
        private readonly IStoryAction FirstAction;
        private IStoryAction CurrentAction;
        private readonly ActionsRepository _actionsRepository;

        private const string InitialActionId = "s9mJThwdNVPW_bmVjUiE-1";
        private readonly string[] LastActionIds = { "SmOhq9sCI9yzw1fIaUKF-127", "SmOhq9sCI9yzw1fIaUKF-76", "SmOhq9sCI9yzw1fIaUKF-30",
            "SmOhq9sCI9yzw1fIaUKF-100", "Ocsp_ow847kPlsqR-XV0-15", };

        public ActionEngine()
        {
            _actionsRepository = new ActionsRepository();
            FirstAction = _actionsRepository.GetStory(InitialActionId);
            CurrentAction = FirstAction;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            _actionsRepository.Dispose();
        }

        public void RunStory()
        {
            StartScreen.PrintStartScreen();
            while (true)
            {
                CurrentAction.InvokeAction();
                CurrentAction = _actionsRepository.GetStory(CurrentAction.ChosenActionId);
            }
        }
    }
}
