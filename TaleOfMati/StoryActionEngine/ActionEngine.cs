using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleOfMati.Story;

namespace TaleOfMati.StoryActionEngine
{
    public class ActionEngine : IDisposable
    {
        private IStoryAction FirstAction;
        private IStoryAction CurrentAction;
        private ActionsRepository _actionsRepository;

        private const string InitialAction = "s9mJThwdNVPW_bmVjUiE-1";
        private const string LastAction = "SmOhq9sCI9yzw1fIaUKF-17";

        public ActionEngine()
        {
            _actionsRepository = new ActionsRepository();
            FirstAction = _actionsRepository.GetStory(InitialAction);
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
            while (CurrentAction.Id != LastAction)
            {
                CurrentAction.InvokeAction();
                CurrentAction = _actionsRepository.GetStory(CurrentAction.ChosenActionId);
            }
        }
    }
}
