namespace PrisionersDilemma.Core.Strategies;

internal abstract class Probabilistic : IStrategy
{
    private readonly Dictionary<(bool, bool), double> probabilities;
    private (bool, bool)? lastMove;
    private bool lastAction;

    public Probabilistic(Dictionary<(bool, bool), double> probabilities)
    {
        this.probabilities = probabilities;
    }

    public bool GetAction()
    {
        lastAction = lastMove is null || GetProbabilisticAction();
        return lastAction;
    }

    public void SetOpponentsAction(bool oponentAction)
    {
        lastMove = (lastAction, oponentAction);
    }

    private bool GetProbabilisticAction()
    {
        double probability = probabilities[lastMove!.Value];
        return System.Random.Shared.NextDouble() < probability;
    }
}
