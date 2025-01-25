using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRollGameAssignment
{
    public class Dice
    {
        private readonly Random _random;
        private int _numberOfSides;

        public Dice(int numberOfSides, Random random)
        {
            _numberOfSides = numberOfSides;
            _random = random;
        }

        public int GetSides() => _numberOfSides;

        public void SetSides(int numberOfSides)
        {
            if (numberOfSides > 0)
            {
                _numberOfSides = numberOfSides;
            }
        }

        public int RollDice()
        {
            return _random.Next(1 , _numberOfSides + 1);
        }
    }
}
