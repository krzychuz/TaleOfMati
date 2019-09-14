using HtmlAgilityPack;
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
                        var newActionNode = new StoryActionBase();
                        newActionNode.Id = element.Source;
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
                HtmlDocument document = new HtmlDocument();
                document.LoadHtml(nodeValue);
                HtmlNodeCollection spanNodeCollection = document.DocumentNode.SelectNodes("//span");
                List<HtmlNode> textNodeCollection = document.DocumentNode.ChildNodes.Where(node => node.NodeType == HtmlNodeType.Text).ToList();

                if (spanNodeCollection?.Count == 2)
                {
                    actionNode.PlaceDescription = spanNodeCollection.ElementAt(0).InnerText;
                    actionNode.ActionDescription = spanNodeCollection.ElementAt(1).InnerText;
                }
                else if (spanNodeCollection?.Count == 1)
                {
                    actionNode.ActionDescription = spanNodeCollection.ElementAt(0).InnerText;
                    actionNode.PlaceDescription = "Lokalizacja nieznana";
                }
                else if (textNodeCollection?.Count > 0)
                {
                    actionNode.PlaceDescription = textNodeCollection.ElementAt(0).InnerText;
                    actionNode.ActionDescription = textNodeCollection.ElementAt(1).InnerText;
                }
                else
                {
                    actionNode.ActionDescription = nodeValue;
                    actionNode.PlaceDescription = "Lokalizacja nieznana";
                }

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
