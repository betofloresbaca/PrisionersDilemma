namespace PrisionersDilemma.Core;

using PrisionersDilemma.Core.Strategies;
using PrisionersDilemma.Core.Utils;

public class Runner
{
    private readonly Dictionary<string, Type> strategies;

    Dictionary<(bool, bool), int> pointMap =
        new()
        {
            { (false, false), 1 },
            { (false, true), 5 },
            { (true, false), 0 },
            { (true, true), 3 },
        };

    public Runner(string namespc)
    {
        this.strategies = ReflectionUtils
            .GetTypesImplementingInterface<IStrategy>(namespc)
            .ToDictionary(x => x.Name, x => x);
    }

    public MatchResults RunMatch(
        string strategy1,
        string strategy2,
        int rounds = 200,
        double noise = 0.0
    )
    {
        var strategy1Type = strategies[strategy1];
        var strategy2Type = strategies[strategy2];
        var strategy1Instance = ReflectionUtils.CreateInstance<IStrategy>(strategy1Type);
        var strategy2Instance = ReflectionUtils.CreateInstance<IStrategy>(strategy2Type);
        var strategy1Results = new StrategyResults { StrategyName = strategy1 };
        var strategy2Results = new StrategyResults { StrategyName = strategy2 };
        for (int i = 0; i < rounds; i++)
        {
            bool strategyAction = AddNoise(strategy1Instance.GetAction(), noise);
            bool oponentAction = AddNoise(strategy2Instance.GetAction(), noise);
            strategy1Results.Actions.Add(strategyAction);
            strategy2Results.Actions.Add(oponentAction);
            strategy1Results.Points += pointMap[(strategyAction, oponentAction)];
            strategy2Results.Points += pointMap[(oponentAction, strategyAction)];
            strategy1Instance.SetOpponentsAction(oponentAction);
            strategy2Instance.SetOpponentsAction(strategyAction);
        }
        return new MatchResults
        {
            Content1Results = strategy1Results,
            Content2Results = strategy2Results
        };
    }

    public Dictionary<string, int> RunContest(int rounds = 200, double noise = 0.0)
    {
        Dictionary<string, int> contestResults = new();
        foreach (var strategy in strategies.Keys)
        {
            var points = 0;
            foreach (var oponent in strategies.Keys)
            {
                MatchResults results = this.RunMatch(strategy, oponent, rounds, noise);
                points += results.Content1Results.Points;
            }
            contestResults.Add(strategy, points);
        }
        return contestResults;
    }

    public Dictionary<string, double> RunMeanContest(
        int contests,
        int rounds = 200,
        double noise = 0.0
    )
    {
        Dictionary<string, double> contestResults = new();
        for (int i = 0; i < contests; i++)
        {
            contestResults = this.RunContest(rounds, noise)
                .ToList()
                .Select(x =>
                    (
                        x.Key,
                        x.Value * 1.0 / contests
                            + (contestResults.ContainsKey(x.Key) ? contestResults[x.Key] : 0)
                    )
                )
                .ToDictionary(x => x.Item1, x => x.Item2);
        }
        return contestResults;
    }

    private bool AddNoise(bool action, double noise)
    {
        return System.Random.Shared.NextDouble() < noise ? !action : action;
    }
}
