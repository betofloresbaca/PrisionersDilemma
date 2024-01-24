namespace PrisionersDilemma.Strategies;

/// <summary>
/// Cooperates the two first moves, then defects only
/// if the opponent has defected during the two previous moves.
/// </summary>
internal class TitForTwoTat : IStrategy
{
    private bool[] LastOpponentActions = [true, true];

    public bool GetAction()
    {
        return LastOpponentActions[0] || LastOpponentActions[1];
    }

    public void SetOpponentsAction(bool action)
    {
        LastOpponentActions[0] = LastOpponentActions[1];
        LastOpponentActions[1] = action;
    }
}
