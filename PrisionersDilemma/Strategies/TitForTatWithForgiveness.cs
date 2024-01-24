namespace PrisionersDilemma.Strategies;

internal class TitForTatWithForgiveness : IStrategy
{
    private bool LastOpponentAction = true;

    public bool GetAction()
    {
        return LastOpponentAction || System.Random.Shared.NextDouble() < 0.5;
    }

    public void SetOpponentsAction(bool action)
    {
        this.LastOpponentAction = action;
    }
}
