using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ResXWriter
{
    class Program
    {
        static void Main(string[] args)
        {

            using (ResXResourceWriter resx = new ResXResourceWriter(@".\CarResources.resx"))
            {
                resx.AddResource("Green", Color.Green);
                resx.AddResource("Red", Color.Red);
                resx.AddResource("Yellow", Color.Yellow);
                resx.AddResource("Cyan", Color.Cyan);
                resx.AddResource("Black", Color.Black);
                resx.AddResource("Brown", Color.Brown);
                resx.AddResource("Pink", Color.Pink);
            }

            // read resourse
            string resxFile = @".\CarResources.resx";

            using (ResXResourceReader resxReader = new ResXResourceReader(resxFile))
            {
                foreach (DictionaryEntry entry in from DictionaryEntry entry in resxReader let value = (Color)entry.Value select entry)
                {
                    Console.WriteLine(entry.Key + " " + entry.Value);
                }
                
                // Convert the result to Dictionary
                var entries =
                    (from DictionaryEntry entry in resxReader
                        select new {entry.Key, entry.Value}).
                        ToDictionary(d=> d.Key);

                var colourGreen = entries["Green"];
            }

            Console.ReadLine();

        }
    }
}

