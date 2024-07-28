namespace ProjectTemplate.Core {
	public static class Data {

		// Graphics Data
		public static int screenW { get; set; } = 1280;
		public static int screenH { get; set; } = 720;
		public static bool Exit { get; set; } = false;

		// Game Scene Data
		public enum Scenes { Menu, Game }
		public static Scenes CurrentState { get; set; } = Scenes.Game;
		public static Scenes LastState { get; set; } = Scenes.Game;

		// Other helper vars
		public static bool DEBUG { get; set; } = true;
		public static float FPS { get; set; } = 0;

	}
}
