using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Bokonokupiku
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Boko : Microsoft.Xna.Framework.GameComponent
    {
        Texture2D rightWalk;
        Texture2D leftWalk;
        Texture2D currentWalk;

        Rectangle destRec;
        Rectangle sourceRec;
        Vector2 bokoWalk = new Vector2();

        float elapsed;
        float delay = 200f;
        int frames;

        public Boko(Game game, Texture2D leftWalk, Texture2D rightWalk)
            : base(game)
        {
            // TODO: Construct any child components here
           
            this.rightWalk = rightWalk;
            this.leftWalk = leftWalk; 

        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here
            destRec = new Rectangle(100, 100, 64, 64);

            base.Initialize();
        }

        private void Animate(GameTime gameTime)
        {
            elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (elapsed >= delay)
            {
                KeyboardState ks = Keyboard.GetState();
                if (frames == 2)
                {
                    frames = 0;
                }

                else
                {
                    frames++;
                }

                elapsed = 0;
            }
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            int maxX = Game.Window.ClientBounds.Width - sourceRec.Width * 2;
            int minX = 0;
            int maxY = Game.Window.ClientBounds.Height - sourceRec.Height * 2;
            int minY = 0;
            

            if (Keyboard.GetState().IsKeyDown(Keys.Right) && !Keyboard.GetState().IsKeyDown(Keys.Up) && !Keyboard.GetState().IsKeyDown(Keys.Down))
            {                
                bokoWalk.X += 5f;
                Animate(gameTime);                
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left) && !Keyboard.GetState().IsKeyDown(Keys.Up) && !Keyboard.GetState().IsKeyDown(Keys.Down))
            {                
                bokoWalk.X -= 5f;
                Animate(gameTime);                
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {                
                bokoWalk.Y -= 5f;
                Animate(gameTime);                
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {                
                bokoWalk.Y += 5f;
                Animate(gameTime);                
            }

            if (frames == 1 && Keyboard.GetState().GetPressedKeys().Length == 0)
            {
                elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (elapsed >= delay)
                {
                    frames = 0;
                }
            }

            if (bokoWalk.X >= maxX)
            {
                bokoWalk.X = maxX;
            }

            if (bokoWalk.X <= minX)
            {
                bokoWalk.X = minX;
            }
            if (bokoWalk.Y >= maxY)
            {
                bokoWalk.Y = maxY;
            }

            if (bokoWalk.Y <= minY)
            {
                bokoWalk.Y = minY;
            }

            base.Update(gameTime);
        }

        public Texture2D updateFrame()
        {
            currentWalk = rightWalk;
            
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && !Keyboard.GetState().IsKeyDown(Keys.Up) && !Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                currentWalk = rightWalk;
                return currentWalk;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left) && !Keyboard.GetState().IsKeyDown(Keys.Up) && !Keyboard.GetState().IsKeyDown(Keys.Down))
            {               
                currentWalk = leftWalk;
                return currentWalk;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                currentWalk = leftWalk;
                return currentWalk;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                currentWalk = leftWalk;
                return currentWalk;
            }
            else
            {
                return currentWalk;
            }
            
        }

        public Rectangle bokoDest()
        {
            destRec = new Rectangle((int)bokoWalk.X, (int)bokoWalk.Y, 64, 64);
            return destRec;
        }
        public Rectangle bokoSource()
        {
            sourceRec = new Rectangle(32 * frames, 0, 32, 32);
            return sourceRec;
        }

        public Texture2D bokoFrame(GameTime gameTime)
        {

            //Animate(gameTime);
            sourceRec = new Rectangle(32 * frames, 0, 32, 32);
            currentWalk = updateFrame();

            
            return currentWalk;
        }
    }
}
