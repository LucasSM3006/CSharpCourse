using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRollGameAssignment
{
    public class GamePrinter
    {
        public void PrintEndGame(bool result)
        {
            if (result)
            {
                Console.WriteLine($"You Win!");
            }
            else
            {
                Console.WriteLine($"You Lose!");
            }
        }

        public void PrintStartGame(string starterMessage)
        {
            Console.WriteLine(starterMessage);
        }
    }
}
