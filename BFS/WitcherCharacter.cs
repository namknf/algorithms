namespace Algorithms
{
    using System.Collections.Generic;

    internal class WitcherCharacter
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