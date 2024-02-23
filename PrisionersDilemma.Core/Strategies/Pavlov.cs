namespace PrisionersDilemma.Core.Strategies;

/// <summary>
/// Pavlov starts off cooperating.
/// If the other player cooperates with Pavlov,
///     Pavlov keeps doing whatever it’s doing, even if it was a mistake;
/// if the other player defects,
///     Pavlov switches its behavior, even if it was a mistake.
/// </summary>
internal class Pavlov : IStrategy
{
    private bool IsCooperating = true;

    public bool GetAction()
    {
        return IsCooperating;
    }

    public void SetOpponentsAction(bool opponentsAction)
    {
        if (!opponentsAction)
        {
            IsCooperating = !IsCooperating;
        }
    }
}
