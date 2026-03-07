using System;
using System.Collections.Generic;
using System.Text;

namespace FacadePatternExample
{
    public class ConeService
    {
        public string GetCone()
        {
            Console.WriteLine("Preparing cone...");
            return "Cone";
        }
    }
}
