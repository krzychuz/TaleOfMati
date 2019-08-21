using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaleOfMati.Story
{
    public interface IStoryAction
    {
        string PlaceDescription { get; set; }

        string ActionDescription { get; set; }

        IDictionary<string, IStoryAction> PossibleActions { get; set; }

        IStoryAction ChosenAction { get; set; }

        void InvokeAction();

    }
}
