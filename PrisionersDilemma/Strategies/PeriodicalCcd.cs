namespace PrisionersDilemma.Strategies;

/// <summary>
/// Plays ccd periodically.
/// </summary>
internal class PeriodicalCcd : IStrategy
{
    private int Turn = 0;

    public bool GetAction()
    {
        return Turn++ % 3 != 2;
    }

    public void SetOpponentsAction(bool action) { }
}
