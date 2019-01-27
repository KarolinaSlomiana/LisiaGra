using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxyGame
{
    class Villain:Character
    {
        public void MoveRandomly()
        {
            int directionNumber = StaticHelpers.RandomNumberGenerator.Next(15);
            if (directionNumber < 4)
            {
                Move((Direction)directionNumber);
            }
        }
    }
}
