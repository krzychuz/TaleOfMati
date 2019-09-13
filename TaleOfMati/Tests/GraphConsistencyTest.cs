using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleOfMati.Story;

namespace TaleOfMati.Tests
{
    [TestClass]
    public class GraphConsistencyTest
    {
        [TestMethod]
        public void ActionsWithoutValidChildern()
        {
            using(var actionsRepository = new ActionsRepository())
            {
                var allStories = actionsRepository.GetAllStories();
                var storiesWithSingleAction = allStories.Where(story => story.PossibleActions.Count == 1);

                var invalidStories = new List<IStoryAction>();

                foreach(var story in storiesWithSingleAction)
                {
                    try
                    {
                        string tmp;
                        tmp = story.PossibleActions["ANY"];
                        tmp = story.PossibleActions["AUTO"];
                    }
                    catch(KeyNotFoundException)
                    {
                        invalidStories.Add(story);
                    }
                }

                if(invalidStories.Any())
                {
                    throw new Exception("There are invalid stories in the XML!");
                }
            }
        }
    }
}
