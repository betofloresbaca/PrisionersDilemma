namespace PrisionersDilemma.Core.Strategies;

/// <summary>
/// Plays cd periodically.
/// </summary>
internal class PeriodicalCd : IStrategy
{
    private int turn = 0;

    public bool GetAction()
    {
        return turn++ % 2 == 0;
    }

    public void SetOpponentsAction(bool opponentsAction) { }
}
