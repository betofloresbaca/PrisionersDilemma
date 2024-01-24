using PrisionersDilemma;

Runner runner = new("PrisionersDilemma.Strategies");

Dictionary<string, int> contestResults = runner.RunContest(rounds: 200, noise: 0.0);

contestResults
    .ToList()
    .OrderByDescending(x => x.Value)
    .ToList()
    .ForEach(x => Console.WriteLine($"{x.Key}: {x.Value} points"));

//var matchResult = runner.RunMatch("SuspiciusTitForTat", "PerCcd", rounds: 50, noise: 0.0);
//Console.WriteLine(matchResult);
