using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleOfMati.StoryActionEngine;

namespace TaleOfMati
{
    class Program
    {
        static void Main(string[] args)
        {
            var actionEngine = new ActionEngine();
            actionEngine.RunStory();
            Console.ReadLine();
        }
    }
}
