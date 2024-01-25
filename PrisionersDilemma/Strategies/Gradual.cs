namespace PrisionersDilemma.Strategies;

/// <summary>
///  Plays the sequence d,c,c then always defects if its opponent
///  has cooperated in the moves 2 and 3.
///  Plays as tit_for_tat in other cases(Mathieu et al. 1999).
/// </summary>
internal class Prober : IStrategy
{
    private int turn = 0;

    private bool[] probe = new[] { false, true, true };

    private bool[] probeOpponetActions = new bool[3];

    private bool IsDefeatingRage = false;

    private bool lastOponentAction;

    public bool GetAction()
    {
        if (turn < probe.Length)
        {
            return probe[turn];
        }
        if (IsDefeatingRage)
        {
            return false;
        }
        return lastOponentAction;
    }

    public void SetOpponentsAction(bool opponentsAction)
    {
        if (turn < probe.Length)
        {
            probeOpponetActions[turn] = opponentsAction;
        }
        else if (turn == probe.Length)
        {
            IsDefeatingRage = !probeOpponetActions[1] && !probeOpponetActions[2];
        }
        lastOponentAction = opponentsAction;
        turn += 1;
    }
}
