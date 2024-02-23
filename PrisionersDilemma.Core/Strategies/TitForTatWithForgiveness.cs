namespace PrisionersDilemma.Core.Strategies;

internal class TitForTatWithForgiveness : IStrategy
{
    private bool lastOpponentAction = true;

    public bool GetAction()
    {
        return lastOpponentAction || System.Random.Shared.NextDouble() < 0.5;
    }

    public void SetOpponentsAction(bool opponentsAction)
    {
        this.lastOpponentAction = opponentsAction;
    }
}
