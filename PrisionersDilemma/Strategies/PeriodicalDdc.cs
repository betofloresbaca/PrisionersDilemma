namespace PrisionersDilemma.Strategies;

/// <summary>
/// Plays ddc periodically.
/// </summary>
internal class PeriodicalDdc : IStrategy
{
    private int Turn = 0;

    public bool GetAction()
    {
        return Turn++ % 3 == 2;
    }

    public void SetOpponentsAction(bool action) { }
}
