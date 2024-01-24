namespace PrisionersDilemma.Strategies;

/// <summary>
/// Cooperates the two first moves, then begin to defect
/// after two consecutive defections of its opponent.
/// Returns to cooperation after two consecutive cooperations of its opponent.
/// </summary>
internal class SlowTitForTat : IStrategy
{
    private bool IsCooperating = true;
    private bool[] LastOpponentActions = [true, true];

    public bool GetAction()
    {
        return IsCooperating;
    }

    public void SetOpponentsAction(bool action)
    {
        LastOpponentActions[0] = LastOpponentActions[1];
        LastOpponentActions[1] = action;
        if (LastOpponentActions.All(x => x))
        {
            IsCooperating = true;
        }
        else if (LastOpponentActions.All(x => !x))
        {
            IsCooperating = false;
        }
    }
}
