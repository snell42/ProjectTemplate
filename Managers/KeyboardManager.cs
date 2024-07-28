using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace ProjectTemplate.Managers {

	public class KeyboardManager {

		private Dictionary<Keys, bool> keysDown;

		public KeyboardManager () {
			keysDown = new Dictionary<Keys, bool> ();
		}

		public void Update () {

			foreach ( Keys key in keysDown.Keys ) {
				if ( !Keyboard.GetState ().IsKeyDown ( key ) ) {
					//keysDown[key] = false;
					keysDown.Remove ( key );
				}
			}

		}

		public bool SinglePress ( Keys key ) {

			if ( Keyboard.GetState ().IsKeyDown ( key ) ) {

				if ( !keysDown.ContainsKey ( key ) ) {
					keysDown.Add ( key, false );
				}

				if ( !keysDown[key] ) {
					keysDown[key] = true;
					return true;
				}

			}

			return false;
		}

	}

}