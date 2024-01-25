using PrisionersDilemma;

Runner runner = new("PrisionersDilemma.Strategies");

Dictionary<string, double> contestResults = runner.RunMeanContest(
    contests: 100,
    rounds: 200,
    noise: 0.0
);

contestResults
    .ToList()
    .OrderByDescending(x => x.Value)
    .ToList()
    .ForEach(x => Console.WriteLine($"{x.Key}: {(int)x.Value} points"));

//var matchResult = runner.RunMatch("SuspiciusTitForTat", "PerCcd", rounds: 50, noise: 0.0);
//Console.WriteLine(matchResult);


// https://www.jasss.org/20/4/12.html#axelrod2006
// https://github.com/Mark-MDO47/PrisonDilemmaTourney?tab=readme-ov-file
// [c, c] -> R + R,[d, d] -> P + P,[d, c] -> T + S
