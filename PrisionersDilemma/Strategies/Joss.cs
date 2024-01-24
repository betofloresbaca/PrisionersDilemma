namespace PrisionersDilemma.Strategies;

/// <summary>
/// Starts cooperating, then do the oponent's last action
/// with 10% probability of defecting when it should cooperate.
/// </summary>
internal class Joss : IStrategy
{
    private bool LastOpponentAction = true;

    public bool GetAction()
    {
        return LastOpponentAction && System.Random.Shared.NextDouble() >= 0.1;
    }

    public void SetOpponentsAction(bool action)
    {
        this.LastOpponentAction = action;
    }
}
