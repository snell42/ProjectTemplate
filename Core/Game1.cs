using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectTemplate.Managers;
using System;

namespace ProjectTemplate.Core {

    public class Game1 : Game {

        public static GraphicsDeviceManager graphics;
		public static KeyboardManager keyboardManager;
		public static FrameRateManager framerateManager;
        public static CameraManager cameraManager;
		private static GameStateManager gameStateManager;

		private SpriteBatch spriteBatch;
        
		public static SpriteFont fontComicSans18;

        public Game1 () {

            graphics = new GraphicsDeviceManager ( this );
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            keyboardManager = new KeyboardManager ();
			framerateManager = new FrameRateManager ();
            cameraManager = new CameraManager ();
			gameStateManager = new GameStateManager ();


		}

		protected override void Initialize () {

            // Screen size etc
            graphics.PreferredBackBufferWidth = Data.screenW;
            graphics.PreferredBackBufferHeight = Data.screenH;
            graphics.ApplyChanges ();

            base.Initialize ();

        }

        protected override void LoadContent () {

            spriteBatch = new SpriteBatch ( GraphicsDevice );

            fontComicSans18 = Content.Load<SpriteFont> ( "ComicSans18" );

			gameStateManager.LoadContent ( Content );

		}

        protected override void Update ( GameTime gameTime ) {

			// Handle state changing
			Data.LastState = Data.CurrentState;
            gameStateManager.Update ( gameTime );

            if ( Data.CurrentState != Data.LastState || gameTime.TotalGameTime.TotalSeconds == 0 ) {
				gameStateManager.OnSelected ();
			}

			// Keyboard helper updating
			keyboardManager.Update ();

			// Sample scene switching - can be called in Scenes/*.cs
			if ( keyboardManager.SinglePress ( Keys.D1 ) ) Data.CurrentState = Data.Scenes.Menu;
            if ( keyboardManager.SinglePress ( Keys.D2 ) ) Data.CurrentState = Data.Scenes.Game;
            if ( keyboardManager.SinglePress ( Keys.F3 ) ) Data.DEBUG = !Data.DEBUG;

			// Handle "safely" closing the game for everything
			if ( Data.Exit || Keyboard.GetState ().IsKeyDown ( Keys.Escape ) )
				Exit ();

			
			base.Update ( gameTime );
        }

        protected override void Draw ( GameTime gameTime ) {

            GraphicsDevice.Clear ( Color.CornflowerBlue );
			
            // Draw based on whatever state is being rendered
            gameStateManager.Draw ( spriteBatch );

			// Debug information
			framerateManager.Update ( gameTime );
			if ( Data.DEBUG ) {
				spriteBatch.Begin ();
                spriteBatch.DrawString (
                    fontComicSans18,
                    string.Join ( Environment.NewLine,
                        $"Gamestate: {Data.CurrentState}",
                        $"FPS: {Data.FPS}"
                    ),
                    new Vector2 ( 10, 10 ),
                    Color.White
                );
                spriteBatch.End ();
            }

            
            base.Draw ( gameTime );
        }
    }
}
