using System.Collections.Generic;
using Assets.Scripts.Exceptions;
using Assets.Scripts.Interfaces;

namespace Assets.Scripts.Entities
{
    public class UniqueNumberGenerator : IUniqueGenerator<int>
    {
        public UniqueNumberGenerator()
        {
            _random = new System.Random();
            _bookedNumbers = new List<int>();
        }

        public int GetUnique(int min, int max)
        {
            var number = _random.Next(min, max);
            if (!_bookedNumbers.Contains(number))
            {
                _bookedNumbers.Add(number);
                _countOfIterations = 0;
                return number;
            }

            if (++_countOfIterations > _bookedNumbers.Count)
            {
                throw new UniqueNumberOutOfRangeException();
            }

            return GetUnique(min, max);
        }

        private readonly System.Random _random;
        private readonly List<int> _bookedNumbers;
        private int _countOfIterations;
    }
}