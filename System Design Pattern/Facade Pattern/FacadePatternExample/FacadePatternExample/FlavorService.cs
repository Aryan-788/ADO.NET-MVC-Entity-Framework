using System;
using System.Collections.Generic;
using System.Text;

namespace FacadePatternExample
{
    public class FlavorService
    {
        public string GetFlavorService()
        {
            Console.WriteLine("Checking Available Flavor...");
            return "Vanilla Ice Cream.";
        }
    }
}
