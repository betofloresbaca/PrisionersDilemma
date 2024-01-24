namespace PrisionersDilemma.Strategies;

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

    public void SetOpponentsAction(bool action)
    {
        if (!action)
        {
            this.IsCooperating = false;
        }
    }
}
