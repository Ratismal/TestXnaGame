using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using xTile;
using xTileGame1.Ref;
using xTileGame1.Sprites;
using Rectangle = xTile.Dimensions.Rectangle;


namespace xTileGame1.Characters
{
    class BaseCharacter
    {
        public MobileSprite sprite;
        private Texture2D texture;

        public BaseCharacter(string textureName)
        {
            texture = RefNames.content.Load<Texture2D>(textureName);
        }

        public void init()
        {
            sprite = new MobileSprite(texture);
        }

        public void SetPos(float x, float y)
        {
            sprite.Position = new Vector2(x, y);
        }

        public Vector2 oldPosition;

        public void MoveBy(int x, int y)
        {
            sprite.Sprite.MoveBy(x, y);
        }

        public void Update(GameTime gameTime, Map map, Rectangle viewport)
        {
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }
    }
}
