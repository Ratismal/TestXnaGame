using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TestGame.Sprites;
using xTile;
using TestGame.Ref;
using Rectangle = xTile.Dimensions.Rectangle;


namespace TestGame.Characters
{
    class BaseCharacter
    {
        public MobileSprite sprite;
        private Texture2D texture;

        /// <summary>
        /// Character constructor
        /// </summary>
        /// <param name="texture">The character's sprite</param>
        public BaseCharacter(Texture2D texture)
        {
            this.texture = texture;
        }

        /// <summary>
        /// Character initialization
        /// </summary>
        public virtual void Initialize()
        {
            sprite = new MobileSprite(texture);
        }

        /// <summary>
        /// Set's the sprite's position to the X and Y value
        /// </summary>
        /// <param name="x">X of the sprite</param>
        /// <param name="y">Y of the sprite</param>
        public void SetPos(float x, float y)
        {
            sprite.Position = new Vector2(x, y);
        }

        public Vector2 oldPosition;

        /// <summary>
        /// Move the sprite by X and Y values
        /// </summary>
        /// <param name="x">The X value to move the sprite by</param>
        /// <param name="y">The Y value to move the sprite by</param>
        public void MoveBy(int x, int y)
        {
            sprite.Sprite.MoveBy(x, y);
        }

        /// <summary>
        /// Update the character
        /// </summary>
        /// <param name="gameTime">GameTime</param>
        /// <param name="map">Map the character is on</param>
        /// <param name="viewport">Viewport the character is on</param>
        /// <returns>The modified viewport (player only)</returns>
        public virtual Rectangle Update(GameTime gameTime, Map map, Rectangle viewport)
        {
            
            sprite.Update(gameTime);
            return viewport;
        }

        /// <summary>
        /// Draw the character
        /// </summary>
        /// <param name="spriteBatch">Batch to draw the sprite in</param>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }
    }
}
