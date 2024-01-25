namespace PrisionersDilemma.Strategies;

/// <summary>
/// Cooperates on the first move then plays what its opponent
/// played the previous move (Rapoport & Chammah 1965).
/// </summary>
internal class TitForTat : IStrategy
{
    private bool lastOpponentAction = true;

    public bool GetAction()
    {
        return lastOpponentAction;
    }

    public void SetOpponentsAction(bool opponentsAction)
    {
        this.lastOpponentAction = opponentsAction;
    }
}
