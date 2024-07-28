using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ProjectTemplate.Core;
using System.Diagnostics;

namespace ProjectTemplate.Scenes {
	internal class MenuScene : GameLoop {

		internal override void OnSelected () {

			Debug.Print ( "Selected Menu" );

		}

		internal override void LoadContent ( ContentManager content ) {

		}

		internal override void Update ( GameTime gameTime ) {

		}

		internal override void Draw ( SpriteBatch spriteBatch ) {

			spriteBatch.Begin ();

			spriteBatch.End ();

		}

	}
}
