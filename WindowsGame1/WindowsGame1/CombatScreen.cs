using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Bokonokupiku
{
    class CombatScreen : GameScreen
    {
        KeyboardState keyboardState;
        Texture2D boko;
        Texture2D enemy;
        Rectangle imageRectangleBoko;
        Rectangle imageRectangleEnemy;
        CombatComponent combatComponent;
        

        

        public CombatScreen(Game game, SpriteBatch spriteBatch, Texture2D boko, Texture2D enemy, SpriteFont spriteFont) : base(game, spriteBatch)
        {
            string[] menuItems = { "Rifle", "Knife" };
            combatComponent = new CombatComponent(game, spriteBatch, spriteFont, menuItems);
            Components.Add(combatComponent);
            this.boko = boko;
            this.enemy = enemy;
            imageRectangleBoko = new Rectangle(150, 200, 128, 128);
            imageRectangleEnemy = new Rectangle(600, 50, 128, 128);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            keyboardState = Keyboard.GetState();
            
           
        }

        public override void Draw(GameTime gameTime)
        {

            spriteBatch.Draw(boko, imageRectangleBoko, Color.Wheat);
            spriteBatch.Draw(enemy, imageRectangleEnemy, Color.Wheat);

            base.Draw(gameTime);
        }
    }
}
