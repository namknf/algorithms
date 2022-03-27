namespace Algorithms.Library.BFS
{
    using System.Collections.Generic;

    public class WitcherCharacter
    {
        private readonly List<WitcherCharacter> _charactersList = new List<WitcherCharacter>();

        public WitcherCharacter(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public List<WitcherCharacter> Characters
        {
            get
            {
                return _charactersList;
            }
        }

        public void IsCharacterOf(WitcherCharacter character)
        {
            _charactersList.Add(character);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
