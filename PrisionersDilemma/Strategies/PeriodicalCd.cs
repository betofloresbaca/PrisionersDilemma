namespace PrisionersDilemma.Strategies;

/// <summary>
/// Plays cd periodically.
/// </summary>
internal class PeriodicalCd : IStrategy
{
    private int Turn = 0;

    public bool GetAction()
    {
        return Turn++ % 2 == 0;
    }

    public void SetOpponentsAction(bool action) { }
}
