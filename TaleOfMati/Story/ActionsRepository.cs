using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleOfMati.ModelDeserializer;

namespace TaleOfMati.Story
{
    public class ActionsRepository : IDisposable
    {
        private IList<IStoryAction> _storyActions;
        private const string StoriesPath = "C:\\Users\\krzyc\\Desktop\\TaleOfMati.xml";

        public ActionsRepository()
        {
            using (DiagramDeserializer diagramDeserializer = new DiagramDeserializer())
            {
                _storyActions = diagramDeserializer.GetStoriesFromXml(StoriesPath);
            }
        }

        public IStoryAction GetStory(string id)
        {
            return _storyActions.Where(action => action.Id == id).SingleOrDefault();
        }

        public IList<IStoryAction> GetAllStories()
        {
            return _storyActions;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isDisposing)
        {
        }
    }
}
