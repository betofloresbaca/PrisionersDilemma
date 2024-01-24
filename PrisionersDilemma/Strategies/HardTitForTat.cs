namespace PrisionersDilemma.Strategies;

/// <summary>
/// Cooperates the two first moves, then defects only if
/// the opponent has defected one of the two previous moves.
/// </summary>
internal class HardTitForTat : IStrategy
{
    private int turn = 0;
    private bool[] lastOpponentActions = [true, true];

    public bool GetAction()
    {
        return turn++ < 2 || lastOpponentActions.All(x => x);
    }

    public void SetOpponentsAction(bool action)
    {
        lastOpponentActions[0] = lastOpponentActions[1];
        lastOpponentActions[1] = action;
    }
}
