using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleOfMati.StoryActionEngine;
using TaleOfMati.DrawIoModel;

namespace TaleOfMati
{
    class Program
    {
        static void Main(string[] args)
        {
            using(ActionEngine actionEngine = new ActionEngine())
            {
                actionEngine.RunStory();
            }
            Console.ReadLine();
        }
    }
}
