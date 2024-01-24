namespace PrisionersDilemma.Strategies;

/// <summary>
/// Always defects.
/// </summary>
internal class AllD : IStrategy
{
    public bool GetAction()
    {
        return false;
    }

    public void SetOpponentsAction(bool action) { }
}
