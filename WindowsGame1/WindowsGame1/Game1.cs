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
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D rightWalk;
        Texture2D leftWalk;
        Texture2D currentWalk;

        KeyboardState currentKeyboardState;
        KeyboardState oldKeyboardState;

        GameScreen activeScreen;
        StartScreen startScreen;
        ActionScreen actionScreen;
        PauseScreen pauseScreen;
        CombatScreen combatScreen;


        //MenuComponent menuComponent;
       

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
           
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
         
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
          
            rightWalk = Content.Load<Texture2D>("bokoRight");
            leftWalk = Content.Load<Texture2D>("bokoLeft");
            currentWalk = rightWalk;

            spriteBatch = new SpriteBatch(GraphicsDevice);

            startScreen = new StartScreen(this, spriteBatch, Content.Load<SpriteFont>("menuFont"), Content.Load<Texture2D>("bokonokupikuBG"));
            Components.Add(startScreen);
            startScreen.Hide();

            actionScreen = new ActionScreen(this, spriteBatch,leftWalk, rightWalk, Content.Load<Texture2D>("bokoLeftCombat"));
            Components.Add(actionScreen);
            actionScreen.Hide();

            pauseScreen = new PauseScreen(this, spriteBatch, Content.Load<Texture2D>("bokonokupikuPause"), Content.Load<SpriteFont>("menuFont"));
            Components.Add(pauseScreen);
            pauseScreen.Hide();

            combatScreen = new CombatScreen(this, spriteBatch, Content.Load<Texture2D>("bokoRightCombat"), Content.Load<Texture2D>("bokoLeftCombat"), Content.Load<SpriteFont>("menuFont"));
            Components.Add(combatScreen);
            combatScreen.Hide();

            activeScreen = startScreen;
            activeScreen.Show();

            

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        private bool checkKey(Keys theKey)
        {
            return currentKeyboardState.IsKeyUp(theKey) &&
                oldKeyboardState.IsKeyDown(theKey);
        }



        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit

           
            currentKeyboardState = Keyboard.GetState();

            if (activeScreen == startScreen)
            {
                if (checkKey(Keys.Enter)) {
                    if (startScreen.selectedIndex == 0)
                    {
                        activeScreen.Hide();
                        activeScreen = actionScreen;
                        actionScreen.Show();

                    }
                    if (startScreen.selectedIndex == 1)
                    {
                        this.Exit();
                    }
                }
            }

            if (activeScreen == actionScreen && checkKey(Keys.Escape))
            {
                activeScreen.Hide();
                activeScreen = pauseScreen;
                pauseScreen.Show();
            }

            if (activeScreen == actionScreen && checkKey(Keys.M))
            {
                activeScreen.Hide();
                activeScreen = combatScreen;
                combatScreen.Show();
            }

            if (activeScreen == pauseScreen)
            {
                if (checkKey(Keys.Enter))
                {
                    if (pauseScreen.selectedIndex == 1)
                    {
                        activeScreen.Hide();
                        activeScreen = startScreen;
                        startScreen.Show();
                    }
                    if (pauseScreen.selectedIndex == 0)
                    {
                        activeScreen.Hide();
                        activeScreen = actionScreen;
                        actionScreen.Show();

                    }
                    if (pauseScreen.selectedIndex == 2)
                    {
                        this.Exit();
                    }
                }
            }
            
            // TODO: Add your update logic here

            base.Update(gameTime);
            oldKeyboardState = currentKeyboardState;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null);
            base.Draw(gameTime);
            spriteBatch.End();

            // TODO: Add your drawing code here

            
        }
    }
}
