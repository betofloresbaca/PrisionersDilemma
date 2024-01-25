namespace PrisionersDilemma.Strategies;

/// <summary>
/// Cooperates the two first moves, then defects only
/// if the opponent has defected during the two previous moves.
/// </summary>
internal class TitForTwoTat : IStrategy
{
    private bool[] lastOpponentActions = [true, true];

    public bool GetAction()
    {
        return lastOpponentActions[0] || lastOpponentActions[1];
    }

    public void SetOpponentsAction(bool opponentsAction)
    {
        lastOpponentActions[0] = lastOpponentActions[1];
        lastOpponentActions[1] = opponentsAction;
    }
}
