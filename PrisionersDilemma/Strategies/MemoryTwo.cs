namespace PrisionersDilemma.Strategies;

/// <summary>
/// [c, c] -> R + R,[d, d] -> P + P,[d, c] -> T + S
/// Behaves like tit_for_tat: in the first two moves, and then shi s among
/// three strategies all_d, tit_for_tat, tf2t according to the interaction
/// with the opponent on last two moves:
///     a. if the payoff in the two moves is [c, c] and[c, c] then
///         tit_for_tat in the following two moves
///     b. if the payoff in the last move is T+S ([c,d] or[d,c] then
///         tf2t in the following 2 moves
///     c. in all other cases she plays all_d in the following two moves
///     d. if all_d has been chosen twice, she always plays all_d.
/// (Li & Kendall 2013)
/// </summary>
internal class MemoryTwo : IStrategy
{
    const int MEMORY_LENGTH = 2;

    private TitForTat titForTat = new();
    private AllD allD = new();
    private TitForTwoTat titForTwoTat = new();
    private IStrategy currentStrategy;
    private bool currentTurnAction;
    private int currentStrategyLeftMoves = MEMORY_LENGTH;
    private Queue<(bool, bool)> memory;
    private int timesChoosenAllD = 0;

    public MemoryTwo()
    {
        currentStrategy = titForTat;
        memory = new Queue<(bool, bool)>();
        for (int i = 0; i < MEMORY_LENGTH; i++)
        {
            memory.Enqueue((false, false));
        }
    }

    public bool GetAction()
    {
        currentTurnAction = currentStrategy.GetAction();
        currentStrategyLeftMoves -= 1;
        return currentTurnAction;
    }

    public void SetOpponentsAction(bool action)
    {
        titForTat.SetOpponentsAction(action);
        allD.SetOpponentsAction(action);
        titForTwoTat.SetOpponentsAction(action);
        UpdateMemory(action);
        if (currentStrategyLeftMoves == 0)
        {
            ChooseNextStrategy();
            currentStrategyLeftMoves = MEMORY_LENGTH;
        }
    }

    private void ChooseNextStrategy()
    {
        if (timesChoosenAllD >= 2)
        {
            currentStrategy = allD;
            timesChoosenAllD += 1;
        }
        else if (memory.All(x => x.Item1 != x.Item2))
        {
            currentStrategy = titForTwoTat;
        }
        else if (memory.All(x => x.Item1 && x.Item2))
        {
            currentStrategy = titForTat;
        }
        else
        {
            currentStrategy = allD;
            timesChoosenAllD += 1;
        }
    }

    private void UpdateMemory(bool action)
    {
        memory.Enqueue((currentTurnAction, action));
        memory.Dequeue();
    }
}
