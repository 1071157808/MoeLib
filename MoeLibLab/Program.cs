using System;
using System.Collections.Generic;

namespace MoeLibLab
{
    public class Apple
    {
        public string Color { get; set; }
        public Dictionary<string, object> Infos { get; set; }
        public DateTime ProductTime { get; set; }
        public int Size { get; set; }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}