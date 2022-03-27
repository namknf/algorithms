namespace Algorithms.Library.BFS
{
    using System;
    using System.Collections.Generic;

    public class BreadthFirstSearch : WitcherCharacter
    {
        public BreadthFirstSearch(string name)
            : base(name)
        {
        }

        public WitcherCharacter BuildWitchersGraph()
        {
            WitcherCharacter geralt = new WitcherCharacter("Geralt");
            WitcherCharacter ciri = new WitcherCharacter("Ciri");
            WitcherCharacter yennefer = new WitcherCharacter("Yennefer");
            geralt.IsCharacterOf(ciri);
            ciri.IsCharacterOf(yennefer);

            WitcherCharacter dandelion = new WitcherCharacter("Dandelion");
            WitcherCharacter tissaia = new WitcherCharacter("Tissaia");
            WitcherCharacter istredd = new WitcherCharacter("Istredd");
            WitcherCharacter dara = new WitcherCharacter("Dara");
            ciri.IsCharacterOf(dandelion);
            ciri.IsCharacterOf(istredd);
            yennefer.IsCharacterOf(tissaia);
            yennefer.IsCharacterOf(dara);

            return geralt;
        }

        public WitcherCharacter Search(WitcherCharacter root, string nameToSearchFor)
        {
            Queue<WitcherCharacter> visited = new Queue<WitcherCharacter>();
            HashSet<WitcherCharacter> setting = new HashSet<WitcherCharacter>();
            visited.Enqueue(root);
            setting.Add(root);

            while (visited.Count > 0)
            {
                WitcherCharacter e = visited.Dequeue();
                if (e.Name == nameToSearchFor)
                {
                    return e;
                }

                foreach (WitcherCharacter friend in e.Characters)
                {
                    if (!setting.Contains(friend))
                    {
                        visited.Enqueue(friend);
                        setting.Add(friend);
                    }
                }
            }

            return null;
        }

        public void Traverse(WitcherCharacter root)
        {
            Queue<WitcherCharacter> traverseOrder = new Queue<WitcherCharacter>();

            Queue<WitcherCharacter> visited = new Queue<WitcherCharacter>();
            HashSet<WitcherCharacter> setting = new HashSet<WitcherCharacter>();
            visited.Enqueue(root);
            setting.Add(root);

            while (visited.Count > 0)
            {
                WitcherCharacter e = visited.Dequeue();
                traverseOrder.Enqueue(e);

                foreach (WitcherCharacter charact in e.Characters)
                {
                    if (!setting.Contains(charact))
                    {
                        visited.Enqueue(charact);
                        setting.Add(charact);
                    }
                }
            }

            while (traverseOrder.Count > 0)
            {
                WitcherCharacter e = traverseOrder.Dequeue();
                Console.WriteLine(e);
            }
        }
    }
}
