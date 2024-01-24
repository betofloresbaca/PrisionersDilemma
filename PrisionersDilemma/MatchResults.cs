namespace PrisionersDilemma;

internal class MatchResults
{
    public StrategyResults Content1Results { get; set; }

    public StrategyResults Content2Results { get; set; }

    public override string ToString()
    {
        return $"{Content1Results}\n{Content2Results}";
    }
}
