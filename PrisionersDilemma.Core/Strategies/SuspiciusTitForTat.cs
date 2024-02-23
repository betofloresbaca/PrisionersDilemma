namespace PrisionersDilemma.Core.Strategies;

/// <summary>
///  Defects on the first move then play what my opponent played
///  the previous move (Axelrod 2006).
///  Sometimes also called mistrust.
/// </summary>
internal class SuspiciusTitForTat : IStrategy
{
    private bool lastOpponentAction = false;

    public bool GetAction()
    {
        return lastOpponentAction;
    }

    public void SetOpponentsAction(bool opponentsAction)
    {
        this.lastOpponentAction = opponentsAction;
    }
}
