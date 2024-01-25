namespace PrisionersDilemma.Strategies;

/// <summary>
/// Plays ccd periodically.
/// </summary>
internal class PeriodicalCcd : IStrategy
{
    private int turn = 0;

    public bool GetAction()
    {
        return turn++ % 3 != 2;
    }

    public void SetOpponentsAction(bool opponentsAction) { }
}
