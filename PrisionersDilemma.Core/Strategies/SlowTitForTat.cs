namespace PrisionersDilemma.Core.Strategies;

/// <summary>
/// Cooperates the two first moves, then begin to defect
/// after two consecutive defections of its opponent.
/// Returns to cooperation after two consecutive cooperations of its opponent.
/// </summary>
internal class SlowTitForTat : IStrategy
{
    private bool isCooperating = true;
    private bool[] lastOpponentActions = [true, true];

    public bool GetAction()
    {
        return isCooperating;
    }

    public void SetOpponentsAction(bool opponentsAction)
    {
        lastOpponentActions[0] = lastOpponentActions[1];
        lastOpponentActions[1] = opponentsAction;
        if (lastOpponentActions.All(x => x))
        {
            isCooperating = true;
        }
        else if (lastOpponentActions.All(x => !x))
        {
            isCooperating = false;
        }
    }
}
