using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestGame.Characters
{
    class Characters
    {
        public static PlayerCharacter playerCharacter;

        /// <summary>
        /// Initialize all the characters
        /// </summary>
        public static void init()
        {
            playerCharacter = new PlayerCharacter();
            playerCharacter.Initialize();
        }
    }
}
