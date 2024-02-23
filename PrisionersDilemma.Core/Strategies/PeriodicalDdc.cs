namespace PrisionersDilemma.Core.Strategies;

/// <summary>
/// Plays ddc periodically.
/// </summary>
internal class PeriodicalDdc : IStrategy
{
    private int turn = 0;

    public bool GetAction()
    {
        return turn++ % 3 == 2;
    }

    public void SetOpponentsAction(bool opponentsAction) { }
}
