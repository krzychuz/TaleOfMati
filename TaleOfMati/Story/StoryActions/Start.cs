using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaleOfMati.Story.StoryActions
{
    public class Start : StoryActionBase
    {
        public Start() : base()
        {
            PlaceDescription = PlacesDescriptions.Bedroom;
            ActionDescription = "Dzwoni budzik. Obudziłeś się właśnie w sypialni. Jest 4.30. Czy wstajesz?";
            PossibleActions["tak"] = new MorningDrink();
        }
    }
}
