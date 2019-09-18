using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TaleOfMati.DrawIoModel;
using TaleOfMati.Story;

namespace TaleOfMati.ModelDeserializer
{
    public class DiagramDeserializer : IDisposable
    {
        public List<IStoryAction> GetStoriesFromXml(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(MxFile));
            MxFile file;
            List <IStoryAction> actionList = new List<IStoryAction>();

            using (Stream reader = new FileStream(fileName, FileMode.Open))
            {
                file = (MxFile)serializer.Deserialize(reader);
            }

            foreach(var element in file.Diagram.MxGraphModel.Root.MxCell)
            {
                if(element.Source == null && element.Target == null && element.Value != null)
                {
                    var actionNode = actionList.Where(action => action.Id == element.Id).SingleOrDefault();
                    if(actionNode == null)
                    {
                        actionNode = new StoryActionBase { Id = element.Id };
                        TryParseHtml(element.Value, actionNode);
                        actionList.Add(actionNode);
                    }
                    else
                    {
                        TryParseHtml(element.Value, actionNode);
                    }
                }
                else if(element.Value != null)
                {
                    var actionNode = actionList.Where(action => action.Id == element.Source).SingleOrDefault();
                    if(actionNode == null)
                    {
                        var newActionNode = new StoryActionBase { Id = element.Source };
                        newActionNode.PossibleActions[element.Value ?? "AUTO"] = element.Target;
                        actionList.Add(newActionNode);
                    }
                    else
                    {
                        actionNode.PossibleActions[element.Value] = element.Target;
                    }

                }
            }

            return actionList;
        }

        private void TryParseHtml(string nodeValue, IStoryAction actionNode)
        {
            Regex tagRegex = new Regex(@"<[^>]+>");
            bool hasHtmlTags = tagRegex.IsMatch(nodeValue);

            if (hasHtmlTags)
            {
                string noHtmlNode;

                noHtmlNode = Regex.Replace(nodeValue, "<br.*?>", Environment.NewLine);
                noHtmlNode = Regex.Replace(noHtmlNode, "<.*?>", string.Empty);
                noHtmlNode = Regex.Replace(noHtmlNode, "nbsp;", " ");

                List<string> parsedLines = new List<string>();

                using (StringReader reader = new StringReader(noHtmlNode))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if(!string.IsNullOrEmpty(line))
                            parsedLines.Add(line);
                    }
                }

                if (parsedLines?.Count >= 2)
                {
                    actionNode.PlaceDescription = parsedLines.ElementAt(0);
                    for (int i = 1; i < parsedLines.Count; i++)
                        actionNode.ActionDescription += parsedLines.ElementAt(i);
                }
                else
                    throw new Exception($"Failed to parse `{nodeValue}`!");

            }
            else
            {
                actionNode.ActionDescription = nodeValue;
                actionNode.PlaceDescription = "Lokalizacja nieznana";
            }
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
