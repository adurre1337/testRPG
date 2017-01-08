using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bokonokupiku
{
    class ActionScreen : GameScreen
    {

        KeyboardState keyboardState;
        Rectangle imageRectangleEnemy;
        Boko boko;
        Texture2D enemy;
        
        

       

        public ActionScreen(Game game, SpriteBatch spriteBatch, Texture2D leftAnim, Texture2D rightAnim, Texture2D enemy): base(game,spriteBatch)
        {
            this.enemy = enemy;
            imageRectangleEnemy = new Rectangle(600, 50, 64, 64);
            boko = new Boko(game,leftAnim, rightAnim);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            keyboardState = Keyboard.GetState();
            boko.Update(gameTime);
            
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(enemy, imageRectangleEnemy, Color.Wheat);
            spriteBatch.Draw(boko.bokoFrame(gameTime), boko.bokoDest(),boko.bokoSource() , Color.Wheat);
            
            base.Draw(gameTime);
        }
    }
}
