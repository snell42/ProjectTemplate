using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ProjectTemplate.Core {

	internal abstract class GameLoop {

		internal abstract void OnSelected ();

		internal abstract void LoadContent ( ContentManager content );

		internal abstract void Update ( GameTime gameTime );

		internal abstract void Draw ( SpriteBatch spriteBatch );

	}

}
