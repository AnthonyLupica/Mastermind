using Mastermind.GameCore;

internal class Program
{
    private static void Main(string[] args)
    {
        // game initialization
        MastermindGame game = new MastermindGame(args);

        // start the game loop
        game.Start();
    }
}
