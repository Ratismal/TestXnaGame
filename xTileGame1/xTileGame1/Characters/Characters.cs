using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xTileGame1.Characters
{
    class Characters
    {
        public static PlayerCharacter playerCharacter;

        public static void init()
        {
            playerCharacter = new PlayerCharacter();
            playerCharacter.init();
        }
    }
}
