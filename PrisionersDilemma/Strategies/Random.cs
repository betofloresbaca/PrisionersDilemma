namespace PrisionersDilemma.Strategies;

/// <summary>
/// Randomly chooses between cooperating and defecting.
/// </summary>
internal class Random : IStrategy
{
    public bool GetAction()
    {
        return System.Random.Shared.Next(0, 2) == 1;
    }

    public void SetOpponentsAction(bool action) { }
}
