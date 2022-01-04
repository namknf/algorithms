namespace Algorithms
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        private static void Main(string[] args)
        {
            BreadthFirstAlgorithm test = new BreadthFirstAlgorithm("Witcher");
            WitcherCharacter root = test.BuildWitchersGraph();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Intersection graph");
            Console.ResetColor();
            test.Traverse(root);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nSearch in Graph");
            Console.ResetColor();
            WitcherCharacter e = test.Search(root, "Geralt");
            Console.WriteLine(e == null ? "Character not found" : e.Name);
            e = test.Search(root, "Nastya Malkina");
            Console.WriteLine(e == null ? "Character not found" : e.Name);
        }
    }
}