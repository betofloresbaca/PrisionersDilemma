namespace PrisionersDilemma.Core.Strategies;

/// <summary>
/// Cooperates until the opponent defects and thereafter
/// always defects (Axelrod 2006)
/// </summary>
internal class Friedman : IStrategy
{
    private bool IsCooperating = true;

    public bool GetAction()
    {
        return IsCooperating;
    }

    public void SetOpponentsAction(bool opponentsAction)
    {
        if (!opponentsAction)
        {
            this.IsCooperating = false;
        }
    }
}
