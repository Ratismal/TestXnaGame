using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using xTile;
using xTile.Dimensions;
using xTile.Layers;
using xTile.Tiles;
using xTileGame1.Ref;
using xTileGame1.Resources;
using Rectangle = xTile.Dimensions.Rectangle;

namespace xTileGame1.Characters
{
    internal class PlayerCharacter : BaseCharacter
    {
        // Just in case we need to revert it
        private Rectangle oldViewport;

        public PlayerCharacter()
            : base(Resources.Resources.spritePlayerCharacter)
        {
        }

        public void init()
        {
            base.init();
            sprite.Sprite.AddAnimation("neutral", 0, 0, 32, 32, 13, 0.2f);
            sprite.Speed = 4;
            sprite.IsMoving = false;
        }

        public Rectangle Update2(GameTime gameTime, Map map, Rectangle viewport)
        {

            return viewport;
        }

        public Rectangle Update(GameTime gameTime, Map map, Rectangle viewport)
        {
            oldPosition = new Vector2(sprite.Position.X, sprite.Position.Y);
            oldViewport = viewport;
            bool collided;
            Vector2 newPosition = new Vector2(sprite.Position.X, sprite.Position.Y);

            var ms = Mouse.GetState();
            var ks = Keyboard.GetState();
           // Point newPos = new Point(viewport.X, viewport.Y);

            // Get the keys that are down
            var leftkey = ks.IsKeyDown(Keys.A);
            var rightkey = ks.IsKeyDown(Keys.D);
            var downkey = ks.IsKeyDown(Keys.S);
            var upkey = ks.IsKeyDown(Keys.W);

            // This is how fast the player shoud move
            var speed = (int) sprite.Speed;

            if (viewport.Location.X == 0 && leftkey)
            {
                newPosition.X -= speed;
                if (CheckCollisions(map, viewport))
                {
                    newPosition.X = oldPosition.X;
                }
            }
            else if (viewport.Location.X == map.DisplayWidth - viewport.Width && rightkey)
            {
                newPosition.X += speed;
                if (CheckCollisions(map, viewport))
                {
                    newPosition.X = oldPosition.X;
                }
            }

            if (viewport.Location.Y == 0 && upkey)
            {
                newPosition.Y -= speed;
                if (CheckCollisions(map, viewport))
                {
                    newPosition.Y = oldPosition.Y;
                }
            }
            else if (viewport.Location.Y == map.DisplayHeight - viewport.Height && downkey)
            {
                newPosition.Y += speed;
                if (CheckCollisions(map, viewport))
                {
                    newPosition.Y = oldPosition.Y;
                }
            }

            sprite.Position = newPosition;
            //newPosition = new Vector2(sprite.Position.X, sprite.Position.Y);

            // Check if we're moving the sprite or the viewport on the X axis
            if (oldPosition.X != Game1.Graphics.PreferredBackBufferWidth/2)
            {
                // The player is on the left edge
                if (oldPosition.X < Game1.Graphics.PreferredBackBufferWidth/2)
                {
                    if (rightkey)
                    {
                        newPosition.X += speed;
                    }
                    newPosition.X = Math.Min(newPosition.X, Game1.Graphics.PreferredBackBufferWidth/2);
                }
                // The player is on the right edge
                else
                {
                    if (leftkey)
                    {
                        newPosition.X -= speed;
                    }
                    newPosition.X = Math.Min(newPosition.X, Game1.Graphics.PreferredBackBufferWidth);
                }
                
                if (CheckCollisions(map, viewport))
                {
                    newPosition.X = oldPosition.X;
                }
            }
            // We're just moving the viewport
            else
            {
                if (leftkey)
                {
                    viewport.X -= speed;
                }

                if (rightkey)
                {
                    viewport.X += speed;
                }

                if (CheckCollisions(map, viewport))
                {
                    viewport.X = oldViewport.X;
                }
            }

            // Check if we're moving the sprite or the viewport on the Y axis
            if (oldPosition.Y != Game1.Graphics.PreferredBackBufferHeight/2)
            {
                // The player is on the top edge
                if (oldPosition.Y < Game1.Graphics.PreferredBackBufferHeight/2)
                {
                    if (downkey)
                    {
                        newPosition.Y += speed;
                    }
                    newPosition.Y = Math.Min(newPosition.Y, Game1.Graphics.PreferredBackBufferHeight/2);
                }
                // The player is on the bottom edge
                else
                {
                    if (upkey)
                    {
                        newPosition.Y -= speed;
                    }
                    newPosition.Y = Math.Min(newPosition.Y, Game1.Graphics.PreferredBackBufferHeight);
                }

                if (CheckCollisions(map, viewport))
                {
                    newPosition.Y = oldPosition.Y;
                }
            }
            // We're just moving the viewport
            else
            {
                if (downkey)
                {
                    viewport.Y += speed;
                }

                if (upkey)
                {
                    viewport.Y -= speed;
                }

                if (CheckCollisions(map, viewport))
                {
                    viewport.Y = oldViewport.Y;
                }
            }

            sprite.Position = newPosition;

            // Update the map (animated textures)
            map.Update(gameTime.ElapsedGameTime.Milliseconds);

            // Make sure that the viewport isn't off the map
            viewport.Location.X = Math.Max(0, viewport.X);
            viewport.Location.Y = Math.Max(0, viewport.Y);
            viewport.Location.X = Math.Min(
                map.DisplayWidth - viewport.Width, viewport.X);
            viewport.Location.Y = Math.Min(
                map.DisplayHeight - viewport.Height, viewport.Y);

            // Make sure that the sprite isn't off the screen
            float tempX, tempY;
            tempX = Math.Max(0, sprite.Position.X);
            tempX = Math.Min(tempX, Game1.Graphics.PreferredBackBufferWidth - sprite.Sprite.Width);
            tempY = Math.Max(0, sprite.Position.Y);
            tempY = Math.Min(tempY, Game1.Graphics.PreferredBackBufferHeight - sprite.Sprite.Height);
            SetPos(tempX, tempY);

            // Check if the viewport is on the min or max
            
           
           // sprite.Position = newPosition;

            // Do a base update
            base.Update(gameTime, map, viewport);

            //Vector2 actualPosition = GetMapCoords(viewport);
            //  System.Console.WriteLine(actualPosition.X + " " + actualPosition.Y);

            
                return viewport;
            

            // Return the new viewport to the scene
           // return viewport;
        }

        /// <summary>
        ///     Checks if the player collided with anything
        /// </summary>
        /// <param name="viewport">The viewport of the scene</param>
        /// <returns>Whether or not there was a collision</returns>
        public bool CheckCollisions(Map map, Rectangle viewport)
        {
            Layer layer = map.GetLayer("Paths");
            Tile tile;
            Location tileLocation;
            Vector2 location = GetMapLocation(viewport);

            int right = (int) (sprite.CollisionBox.Right + viewport.X) / 32;
            int left = (int) (sprite.CollisionBox.Left + viewport.X) / 32;
            int top = (int) (sprite.CollisionBox.Top + viewport.Y) / 32;
            int bottom = (int) (sprite.CollisionBox.Bottom + viewport.Y) / 32;

            tileLocation = new Location(right, top);
            tile = layer.Tiles[tileLocation];
            if (tile != null && tile.TileIndexProperties["state"] == 0)
                return true;

            tileLocation = new Location(right, bottom);
            tile = layer.Tiles[tileLocation];
            if (tile != null && tile.TileIndexProperties["state"] == 0)
                return true;

            tileLocation = new Location(left, bottom);
            tile = layer.Tiles[tileLocation];
            if (tile != null && tile.TileIndexProperties["state"] == 0)
                return true;

            tileLocation = new Location(left, top);
            tile = layer.Tiles[tileLocation];
            if (tile != null && tile.TileIndexProperties["state"] == 0)
                return true;
 
            return false;
        }

        public Vector2 GetMapLocation(Rectangle viewport)
        {
            //sprite.CollisionBox.
            var x = sprite.Position.X + viewport.X;
            var y = sprite.Position.Y + viewport.Y;
            // map.
            //layer
           // sprite.CollisionBox.
            return new Vector2( x + (sprite.Sprite.Width/2), y - (sprite.Sprite.Height/2));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}