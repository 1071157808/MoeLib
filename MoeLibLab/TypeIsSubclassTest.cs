using System;
using System.Collections.Generic;

namespace MoeLibLab
{
    internal static class TypeIsSubclassTest
    {
        internal static void Test()
        {
            Console.WriteLine(typeof(RedApple).IsSubclassOf(typeof(Apple))); // true
            Console.WriteLine(typeof(RedApple).IsEquivalentTo(typeof(Apple))); // false
            Console.WriteLine(typeof(Apple).IsEquivalentTo(typeof(Apple))); // true
        }
    }

    internal class Apple
    {
        public string Color { get; set; }
        public Dictionary<string, object> Infos { get; set; }
        public DateTime ProductTime { get; set; }
        public int Size { get; set; }
    }

    internal class RedApple : Apple
    {
    }
}