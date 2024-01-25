namespace PrisionersDilemma.Strategies;

internal interface IStrategy
{
    bool GetAction();

    void SetOpponentsAction(bool oponentAction);
}
