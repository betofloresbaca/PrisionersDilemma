namespace PrisionersDilemma.Core.Strategies;

internal interface IStrategy
{
    bool GetAction();

    void SetOpponentsAction(bool oponentAction);
}
