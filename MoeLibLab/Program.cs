using System;
using System.Collections.Generic;
using Newtonsoft.Json;

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
            string a = JsonConvert.SerializeObject(new Dictionary<string, object>
            {
                { "A", new List<Apple> { new Apple() } },
                { "B", 10 }
            });
            Console.WriteLine(a);
        }
    }
}