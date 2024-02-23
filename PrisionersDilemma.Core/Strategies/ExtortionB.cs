namespace PrisionersDilemma.Core.Strategies;

internal class ExtortionB : Probabilistic
{
    public ExtortionB()
        : base(
            new Dictionary<(bool, bool), double>()
            {
                { (true, true), 4.0 / 5.0 },
                { (true, false), 1.0 / 10.0 },
                { (false, true), 3.0 / 5.0 },
                { (false, false), 0.0 },
            }
        ) { }
}
