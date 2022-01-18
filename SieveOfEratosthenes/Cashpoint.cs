namespace CashpointModel
{
    using System;
    using System.Collections.Generic;

    public sealed class Cashpoint
    {
        private readonly IDictionary<uint, uint> _banknotes;

        private readonly bool _isLarge;

        private uint _total;
        private uint _count;

        private uint[] _granted;

        public Cashpoint(bool isLarge, IDictionary<uint, uint> banknotes)
        {
            _banknotes = banknotes;
            _granted = new uint[] { 1 };

            foreach (var banknote in _banknotes)
            {
                CalculateGrants(banknote.Key, banknote.Value);
            }

            _count = (uint)banknotes.Count;
            _isLarge = isLarge;
        }

        public uint Total
        {
            get
            {
                return _total;
            }
        }

        public uint Count
        {
            get
            {
                return _count;
            }
        }

        public IDictionary<uint, uint> Banknotes
        {
            get
            {
                return _banknotes;
            }
        }

        public bool CanGrant(uint value)
        {
            if (value > _total)
            {
                return false;
            }

            return _granted[(int)value] > 0;
        }

        public void AddBanknote(uint value, uint countBanknotes)
        {
            if (_isLarge)
            {
                AddBanknoteLargeInput(value, countBanknotes);
            }
            else
            {
                AddBanknoteSmallInput(value, countBanknotes);
            }
        }

        public void RemoveBanknote(uint value, uint countBankotes)
        {
            if (_isLarge)
            {
                RemoveBanknoteLargeInput(value, countBankotes);
            }
            else
            {
                RemoveBanknoteSmallInput(value, countBankotes);
            }
        }

        private void AddBanknoteLargeInput(uint value, uint number)
        {
            if (number == 0)
            {
                return;
            }

            if (_banknotes.ContainsKey(value))
            {
                _banknotes[value] += number;
                _count += number;
            }
            else
            {
                _banknotes.Add(value, number);
                _count += number;
            }

            CalculateGrants(value, number);
        }

        private void AddBanknoteSmallInput(uint value)
        {
            if (_banknotes.ContainsKey(value))
            {
                _banknotes[value]++;
            }
            else
            {
                _banknotes.Add(value, 1);
            }

            _total += value;
            _count++;

            Array.Resize(ref _granted, (int)_total + 1);

            for (var i = (int)_total; i >= 0; i--)
            {
                if (_granted[i] != 0)
                {
                    _granted[i + value]++;
                }
            }
        }

        private void AddBanknoteSmallInput(uint value, uint countBanknote)
        {
            Array.Resize(ref _granted, (int)_total + 1);

            for (var i = 0; i < countBanknote; i++)
            {
                AddBanknoteSmallInput(value);
            }
        }

        private void RemoveBanknoteLargeInput(uint value, uint number)
        {
            if (number == 0)
            {
                return;
            }

            if (!_banknotes.ContainsKey(value) || _banknotes[value] < number)
            {
                return;
            }

            for (var i = _total; i >= value * _banknotes[value]; i--)
            {
                if (_granted[i] > 0 && _granted[i - (value * _banknotes[value])] > 0 && (i + value > _total || _granted[i + value] == 0))
                {
                    for (var k = 0; k < number; k++)
                    {
                        _granted[i - (k * value)] -= 1;
                    }
                }
            }

            if (_banknotes[value] == 1)
            {
                _banknotes.Remove(value);
            }
            else
            {
                _banknotes[value] -= number;
            }

            _count -= number;
            _total -= value * number;

            Array.Resize(ref _granted, (int)_total + 1);
        }

        private void RemoveBanknoteSmallInput(uint value)
        {
            Array.Resize(ref _granted, (int)_total + 1);

            if (CanGrant(value))
            {
                for (var i = 0; i < (int)_total; i++)
                {
                    if (_granted[i] != 0)
                    {
                        _granted[i + value]--;
                    }
                }
            }

            if (!_banknotes.ContainsKey(value))
            {
                return;
            }

            if (_banknotes[value] == 1)
            {
                _banknotes.Remove(value);
            }
            else
            {
                _banknotes[value]--;
            }

            _total -= value;
            _count--;
        }

        private void RemoveBanknoteSmallInput(uint value, uint countBanknote)
        {
            Array.Resize(ref _granted, (int)_total + 1);

            for (var i = 0; i < countBanknote; i++)
            {
                RemoveBanknoteSmallInput(value);
            }
        }

        private void CalculateGrants(uint value, uint number)
        {
            if (number == 0)
            {
                return;
            }

            _total += value * number;
            Array.Resize(ref _granted, (int)_total + 1);

            for (var i = (int)_total; i >= (_banknotes[value] * value); i--)
            {
                if (_granted[i - (_banknotes[value] * value)] > 0)
                {
                    for (var j = 0; j < number; j++)
                    {
                        _granted[i - (j * value)] += 1;
                    }
                }
            }
        }
    }
}
