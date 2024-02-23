namespace PrisionersDilemma.Core.Strategies;

/// <summary>
/// Begins by cooperating and cooperates as long as the number
/// of times the opponent has cooperated is greater that or equal
/// to the number of times it has defected. Otherwise she defects
/// (Axelrod 2006).
/// </summary>
internal class SoftMajority : IStrategy
{
    public int OponenentActionsBalance = 0;

    public bool GetAction()
    {
        return OponenentActionsBalance >= 0;
    }

    public void SetOpponentsAction(bool opponentsAction)
    {
        OponenentActionsBalance += opponentsAction ? 1 : -1;
    }
}
