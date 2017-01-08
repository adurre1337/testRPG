using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Bokonokupiku
{
    class PauseScreen : GameScreen
    {

        KeyboardState keyboardState;
        Texture2D image;
        Rectangle imageRectangle;
        MenuComponent menuComponent;

        public int selectedIndex
        {
            get { return menuComponent.SelectedIndex; }
            set { menuComponent.SelectedIndex = value; }
        }


        public PauseScreen(Game game, SpriteBatch spriteBatch, Texture2D image, SpriteFont spriteFont) : base(game, spriteBatch)
        {
            string[] menuItems = { "Return to Game?","Return to Main Menu?", "End Game" };
            menuComponent = new MenuComponent(game, spriteBatch, spriteFont, menuItems);
            Components.Add(menuComponent);
            this.image = image;
            imageRectangle = new Rectangle(0, 0, Game.Window.ClientBounds.Width, Game.Window.ClientBounds.Height);
        }

        
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            keyboardState = Keyboard.GetState();
            
           
        }

        public override void Draw(GameTime gameTime)
        {

            spriteBatch.Draw(image, imageRectangle, Color.Wheat);

            base.Draw(gameTime);
        }
    }
}
