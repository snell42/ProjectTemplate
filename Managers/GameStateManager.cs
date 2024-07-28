using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ProjectTemplate.Core;
using ProjectTemplate.Scenes;

namespace ProjectTemplate.Managers {

	internal partial class GameStateManager : GameLoop {

		private MenuScene menuScene = new MenuScene ();
		private GameScene gameScene = new GameScene ();

		internal override void OnSelected () {

			switch ( Data.CurrentState ) {
				case Data.Scenes.Menu:
					menuScene.OnSelected ();
					break;

				case Data.Scenes.Game:
					gameScene.OnSelected ();
					break;

			}

		}

		internal override void LoadContent ( ContentManager content ) {
		
			menuScene.LoadContent ( content );
			gameScene.LoadContent ( content );

		}
		
		internal override void Update ( GameTime gameTime ) {

			switch ( Data.CurrentState ) {
				case Data.Scenes.Menu:
					menuScene.Update ( gameTime );
					break;

				case Data.Scenes.Game:
					gameScene.Update ( gameTime );
					break;

			}

		}

		internal override void Draw ( SpriteBatch spriteBatch ) {

			switch ( Data.CurrentState ) {
				case Data.Scenes.Menu:
					menuScene.Draw ( spriteBatch );
					break;

				case Data.Scenes.Game:
					gameScene.Draw ( spriteBatch );
					break;

			}

		}

	}
}
