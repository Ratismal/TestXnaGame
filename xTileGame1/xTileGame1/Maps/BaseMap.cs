using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xTile;
using TestGame.Ref;

namespace TestGame.Maps
{
    class BaseMap
    {
        public Map map
        {
            get;
        }

        public BaseMap(Map map)
        {
            this.map = map;
        }



    }
}
