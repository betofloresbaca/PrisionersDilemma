namespace PrisionersDilemma.Strategies;

/// <summary>
/// Cooperates on the first move then plays what its opponent
/// played the previous move (Rapoport & Chammah 1965).
/// </summary>
internal class TitForTat : IStrategy
{
    private bool LastOpponentAction = true;

    public bool GetAction()
    {
        return LastOpponentAction;
    }

    public void SetOpponentsAction(bool action)
    {
        this.LastOpponentAction = action;
    }
}
