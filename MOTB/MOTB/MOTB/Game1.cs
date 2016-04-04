using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MOTB
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    /// 
   

    public class Game1 : Game
    {
        enum State { MMENU, OVERWORLD, BATTLE };

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        BattleManager battleMan;

        Unit princess;
        Unit testEnemy;

        Texture2D princessTxt;
        Texture2D mouseTxt;

        List<Unit> heroes = new List<Unit>();
        List<Unit> enemies = new List<Unit>();

        State currentState = State.MMENU;
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
            
            spriteBatch = new SpriteBatch(GraphicsDevice);
            battleMan = new BattleManager();

            Menu.loadButton(Content);
          
            princessTxt = Content.Load<Texture2D>("whiteTest");
            mouseTxt = Content.Load<Texture2D>("mouse");
            princess = new Unit("Palette", new Vector2(200, 150), princessTxt, Color.AntiqueWhite);
            Unit.loadTxt(Content);
            testEnemy = new Unit("TestE", new Vector2(400,150), princessTxt, Color.AntiqueWhite);
            heroes.Add(princess);
            enemies.Add(testEnemy);
            battleMan.startBattle(heroes, enemies);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.B))
            {
                currentState = State.BATTLE;
                
                battleMan.startBattle(heroes,enemies);
            }

            battleMan.update();

            // TODO: Add your update logic here
            switch (currentState)
            {
                case State.MMENU:

                    break;
                case State.OVERWORLD:

                    break;
                case State.BATTLE:

                    break;
                default:

                    break;

            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.BackToFront);
            //draw the mouse
            spriteBatch.Draw(mouseTxt, new Vector2(Mouse.GetState().Position.X, Mouse.GetState().Position.Y), null, Color.White, 0f, new Vector2(mouseTxt.Width / 2, 0), 1f, SpriteEffects.None, 0f);
            switch (currentState)
            {
                case State.MMENU:

                    break;
                case State.OVERWORLD:

                    break;
                case State.BATTLE:
                    battleMan.draw(spriteBatch);
                    break;
                default:

                    break;

            }
            // TODO: Add your drawing code here
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
