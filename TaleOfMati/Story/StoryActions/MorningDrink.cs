using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaleOfMati.Story.StoryActions
{
    public class MorningDrink : StoryActionBase
    {
        public MorningDrink() : base()
        {
            PlaceDescription = PlacesDescriptions.Kitchen;
            ActionDescription = "Mmmm. Ten ekspres To jednak nie taki zły prezent. Kawa jest niezgorsza. " +
                "Szczególnie ta pierwsza, o poranku. Trwa rywalizacja Endomondo. " +
                "Rozważasz jak dostać się do pracy. Samochodem, czy może pieszo...?";
            PossibleActions["pieszo"] = new OnTheWayToWork();
        }
    }
}
