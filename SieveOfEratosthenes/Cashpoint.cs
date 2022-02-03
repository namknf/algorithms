namespace Algorithms
{
    using System;
    using System.Collections.Generic;

    internal delegate void CalculateGrants(uint banknote, uint count);

    public sealed class Cashpoint
    {
        private readonly Dictionary<uint, uint> _banknotes = new ();
        private uint[] _granted = { 1 };
        private uint _count;
        private uint _total;
        private CalculateGrants _calcGrants;

        public uint Total => _total;

        public uint Count => _count;

        public bool CanGrant(uint sum)
        {
            return sum <= _total && (_granted[sum] > 0);
        }

        public void AddBanknote(uint banknote)
        {
            AddBanknote(banknote, 1);
        }

        public void AddBanknote(uint banknote, uint count)
        {
            if (_banknotes.TryGetValue(banknote, out uint value))
            {
                _banknotes[banknote] = count + value;
            }
            else
            {
                _banknotes.Add(banknote, count);
            }

            _calcGrants = SieveForAdd;
            _calcGrants(banknote, count);

            _total += banknote * count;
            _count += count;
        }

        public void RemoveBanknote(uint banknote)
        {
            RemoveBanknote(banknote, 1);
        }

        public void RemoveBanknote(uint banknote, uint count)
        {
            if (_banknotes.TryGetValue(banknote, out uint value))
            {
                if (value >= count)
                {
                    _banknotes[banknote] = value - count;

                    if (_banknotes[banknote] == 0)
                    {
                        _banknotes.Remove(banknote);
                    }

                    _calcGrants = SieveForRemove;
                    _calcGrants(banknote, count);

                    _total -= banknote * count;
                    _count -= count;
                }
            }
        }

        private void SieveForAdd(uint banknote, uint count)
        {
            for (var j = 1; j <= count; j++)
            {
                uint[] grantedG = new uint[_total + (banknote * j) + 1];

                Array.Resize(ref _granted, grantedG.Length);
                Array.Copy(_granted, grantedG, _granted.Length);

                for (var i = 0; i < grantedG.Length; i++)
                {
                    if (_granted[i] > 0)
                    {
                        grantedG[i + banknote] = _granted[i] + _granted[i + banknote];
                    }
                }

                Array.Copy(grantedG, _granted, grantedG.Length);
            }
        }

        private void SieveForRemove(uint banknote, uint count)
        {
            for (var j = 1; j <= count; j++)
            {
                Array.Resize(ref _granted, (int)(_granted.Length - banknote));

                for (var i = banknote; i < _granted.Length; i++)
                {
                    if (_granted[i] > 0)
                    {
                        var diff = i - banknote;

                        if (_granted[diff] > 0)
                        {
                            _granted[i] -= _granted[diff];
                        }
                    }
                }
            }
        }
    }
}
