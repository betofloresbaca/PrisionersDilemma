namespace PrisionersDilemma.Strategies;

/// <summary>
///  Defects on the first move then play what my opponent played
///  the previous move (Axelrod 2006).
///  Sometimes also called mistrust.
/// </summary>
internal class SuspiciusTitForTat : IStrategy
{
    private bool LastOpponentAction = false;

    public bool GetAction()
    {
        return LastOpponentAction;
    }

    public void SetOpponentsAction(bool action)
    {
        this.LastOpponentAction = action;
    }
}
