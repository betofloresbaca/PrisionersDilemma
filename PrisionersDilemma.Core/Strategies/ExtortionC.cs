namespace PrisionersDilemma.Core.Strategies;

internal class ExtortionC : Probabilistic
{
    public ExtortionC()
        : base(
            new Dictionary<(bool, bool), double>()
            {
                { (true, true), 11.0 / 12.0 },
                { (true, false), 5.0 / 24.0 },
                { (false, true), 2.0 / 3.0 },
                { (false, false), 0.0 },
            }
        ) { }
}
