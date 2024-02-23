namespace PrisionersDilemma.Core;

public record StrategyResults
{
    public string StrategyName { get; init; }

    public int Points { get; set; }

    public List<bool> Actions { get; init; } = new List<bool>();

    public override string ToString()
    {
        var actions = string.Join(',', Actions.Select(x => x ? "O" : "X"));
        return $"{StrategyName, -32}({Points, 4}) => [{actions}]";
    }
}
