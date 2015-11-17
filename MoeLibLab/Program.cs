using System;
using System.Collections.Generic;
using Moe.Lib;

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
            Console.WriteLine(Environment.Version.ToJson());
            Console.WriteLine(Environment.OSVersion.ToJson());
        }
    }
}