namespace PrisionersDilemma.Core.Strategies;

/// <summary>
///  Defects on the first move and defects if the number of defections
///  of the opponent is greater than or equal to the number of times
///  she has cooperated. Else she cooperates (Axelrod 2006).
/// </summary>
internal class HardMajority : IStrategy
{
    public int OponenentActionsBalance = 0;

    public bool GetAction()
    {
        return OponenentActionsBalance > 0;
    }

    public void SetOpponentsAction(bool opponentsAction)
    {
        OponenentActionsBalance += opponentsAction ? 1 : -1;
    }
}
