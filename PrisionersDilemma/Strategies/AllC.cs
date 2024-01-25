namespace PrisionersDilemma.Strategies;

/// <summary>
/// Always cooperates.
/// </summary>
internal class AllC : IStrategy
{
    public bool GetAction()
    {
        return true;
    }

    public void SetOpponentsAction(bool opponentsAction) { }
}
