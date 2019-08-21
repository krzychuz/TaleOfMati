using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaleOfMati.Story.StoryActions
{
    public class OnTheWayToWork : StoryActionBase
    {
        public OnTheWayToWork() : base()
        {
            PlaceDescription = PlacesDescriptions.WayToWork;
            ActionDescription = "Najgorsza. Decyzja. Ever. o 7.15 jest już 25*C. " +
                "Mimo krótkich spodenek i przewiewnego t-shirta pocisz się jak świnia. " +
                "Będziesz śmierdział jak Pan Kanapka. Tego zapachu nie ukryją nawet drogie perfumy.";
            PossibleActions["nook"] = new Stop();
        }
    }
}
