using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
        GraphicsDevice device;
        
        SpriteBatch spriteBatch;

        State currentState = State.OVERWORLD;

        Camera2d cam;
        OverWorldPlayer p1;
        World cWorld;

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
            cam = new Camera2d();
            p1 = new OverWorldPlayer(Color.White, new Vector2(100, 500), new Vector2(0, 0));

            this.Window.Title = "Will likes Dicks";
            graphics.PreferredBackBufferWidth = 1280;//720p
            graphics.PreferredBackBufferHeight = 720;
            graphics.ApplyChanges();

            base.Initialize();
            cWorld = new World("1");
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            OverWorldPlayer.load(Content);
            World.load(Content);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {

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

            switch (currentState)
            {
                case State.MMENU:

                    break;
                case State.OVERWORLD:
                    p1.update(cWorld);

                    if (p1.pos.X > 650)
                    {
                        cam._pos.X = p1.pos.X;
                    }
                    else
                    {
                        cam._pos.X = 650;
                    }
                    if (p1.pos.Y < 1235)
                    {
                        cam._pos.Y = p1.pos.Y;
                    }
                    else
                    {
                        cam._pos.Y = 1235;
                    }

                    cWorld.update(cWorld);
                    break;
                case State.BATTLE:

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

            switch (currentState)
            {
                case State.MMENU:
                    spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null, cam.get_transformation(device));

                    spriteBatch.End();
                    break;
                case State.OVERWORLD:
                    spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null, cam.get_transformation(device));
                    p1.draw(spriteBatch);
                    cWorld.draw(spriteBatch,cam.Pos);
                    spriteBatch.End();
                    break;
                case State.BATTLE:
                    spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null, cam.get_transformation(device));
                    
                    spriteBatch.End();
                    break;

            }
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
