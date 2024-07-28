using Microsoft.Xna.Framework;
using ProjectTemplate.Core;
using System.Collections.Generic;
using System.Linq;

namespace ProjectTemplate.Managers {

	public class FrameRateManager {

		private int _totalFrames;
		private float _totalSeconds;
		private float _currentFPS = 0;

		private Queue<float> _framesQueue = new Queue<float> ();
		private const int _queueBuffer = 180;

		public int TotalFrames {
			get { return _totalFrames; }
		}

		public float ElapsedSeconds {
			get { return _totalSeconds; }
		}

		public int FPS_i () {
			return (int) _currentFPS;
		}

		public float FPS_f () {
			return _currentFPS;
		}

		public void Update ( GameTime gameTime ) {

			_framesQueue.Enqueue ( 1.0f / (float) gameTime.ElapsedGameTime.TotalSeconds );

			if ( _framesQueue.Count > _queueBuffer )
				_framesQueue.Dequeue ();

			_currentFPS = _framesQueue.Average ();
			_totalFrames++;
			_totalSeconds += (float) gameTime.ElapsedGameTime.TotalSeconds;
			Data.FPS = _currentFPS;

		}

	}

}