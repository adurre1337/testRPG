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
    public class CombatComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {
        string[] menuItems;
        int selectedIndex;

        Color normal = Color.Black;
        Color highlight = Color.White;

        KeyboardState currentState;
        KeyboardState oldState;

        SpriteBatch spriteBatch;
        SpriteFont spriteFont;

        Vector2 position;
        float height = 0f;
        float width = 0f;

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                selectedIndex = value;
                if (selectedIndex < 0)
                {
                    selectedIndex = 0;
                }
                if (selectedIndex >= menuItems.Length)
                {
                    selectedIndex = menuItems.Length - 1;
                }

            }
        }

        public CombatComponent(Game game, SpriteBatch spriteBatch, SpriteFont spriteFont, string[] menuItems)
            : base(game)
        {
            // TODO: Construct any child components here
            this.spriteBatch = spriteBatch;
            this.spriteFont = spriteFont;
            this.menuItems = menuItems;
            MeasureMenu();
        }

        private void MeasureMenu()
        {
            height = 0;
            width = 0;
            foreach (string item in menuItems)
            {
                Vector2 size = spriteFont.MeasureString(item);
                if (size.X > width)
                {
                    width = size.X;
                }
                height += spriteFont.LineSpacing + 5;
            }
            position = new Vector2(
                (Game.Window.ClientBounds.Width - width) / 6f,
                (Game.Window.ClientBounds.Height - height) / 1.2f);

        }

        private bool checkKey(Keys theKey)
        {
            return currentState.IsKeyUp(theKey) &&
                oldState.IsKeyDown(theKey);
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            currentState = Keyboard.GetState();

            if (checkKey(Keys.Down))
            {
                selectedIndex++;
                if (selectedIndex == menuItems.Length)
                {
                    selectedIndex = 0;
                }
            }

            if (checkKey(Keys.Up))
            {
                selectedIndex--;
                if ((selectedIndex < menuItems.Length))
                {
                    selectedIndex = menuItems.Length - 1;
                }
            }

            base.Update(gameTime);

            oldState = currentState;
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            Vector2 location = position;
            Color tint;

            for (int i = 0; i < menuItems.Length; i++)
            {
                if (i == selectedIndex)
                {
                    tint = highlight;
                    spriteBatch.DrawString(spriteFont, menuItems[i], location, tint);
                    location.Y += spriteFont.LineSpacing + 10;
                }
                else
                {
                    tint = normal;
                    spriteBatch.DrawString(spriteFont, menuItems[i], location, tint);
                    location.Y += spriteFont.LineSpacing + 10;
                }

            }

        }
    }
}
