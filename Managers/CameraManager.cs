using Microsoft.Xna.Framework;
using ProjectTemplate.Core;

namespace ProjectTemplate.Managers {

	public class CameraManager {

		protected float _zoom;
		protected float _rotation; // DEGREES, NOT RADIANS
		protected Vector2 _position;
		protected Vector2 _origin;

		public CameraManager () {
			_zoom = 1.0f;
			_rotation = 0.0f;
			_origin = new Vector2 ( Data.screenW / 2, Data.screenH / 2 );
			_position = Vector2.Zero;
		}

		public float zoom {
			get { return _zoom; }
			set { _zoom = value; if ( _zoom < 0.1f ) _zoom = 0.1f; }
		}

		public float rotation {
			get { return _rotation; }
			set { _rotation = value; _rotation = MathHelper.ToRadians ( _rotation ); }
		}

		public void MovePosition ( Vector2 movement ) {
			_position += movement;
		}

		public void SetPosition ( Vector2 position ) {
			_position = position;
		}

		public Vector2 position {
			get { return _position; }
			set { _position = value; }
		}

		public Vector2 origin {
			get { return _origin; }
			set { _origin = value; }
		}

		public Matrix Transform () {

			Matrix translationMatrix = Matrix.CreateTranslation ( new Vector3 ( -_position.X, -_position.Y, 0.0f ) );
			Matrix rotationMatrix = Matrix.CreateRotationZ ( _rotation );
			Matrix scaleMatrix = Matrix.CreateScale ( _zoom );
			Matrix originMatrix = Matrix.CreateTranslation ( new Vector3 ( _origin.X, _origin.Y, 0 ) );

			return translationMatrix * rotationMatrix * scaleMatrix * originMatrix;

		}

	}

}