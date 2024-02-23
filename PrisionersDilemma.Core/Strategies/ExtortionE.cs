namespace PrisionersDilemma.Core.Strategies;

internal class ExtortionE : Probabilistic
{
    public ExtortionE()
        : base(
            new Dictionary<(bool, bool), double>()
            {
                { (true, true), 17.0 / 20.0 },
                { (true, false), 3.0 / 4.0 },
                { (false, true), 7.0 / 10.0 },
                { (false, false), 0.0 },
            }
        ) { }
}
