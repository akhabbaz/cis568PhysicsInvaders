
public static class StaticClassState { 
    public enum GameState { GameOver, GamePlay, HighScore};
    // store the Mode of the game
    public static GameState gameState = GameState.HighScore;
    public static int CurrentScore = 0;
}
