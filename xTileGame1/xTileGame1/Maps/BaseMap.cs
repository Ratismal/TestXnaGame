using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xTile;
using xTileGame1.Ref;

namespace xTileGame1.Maps
{
    class BaseMap
    {
        public Map map
        {
            get;
        }

        public BaseMap(string mapName)
        {
            map = RefNames.content.Load<Map>(mapName);
        }



    }
}
