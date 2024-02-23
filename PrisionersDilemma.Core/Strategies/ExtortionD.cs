namespace PrisionersDilemma.Core.Strategies;

internal class ExtortionD : Probabilistic
{
    public ExtortionD()
        : base(
            new Dictionary<(bool, bool), double>()
            {
                { (true, true), 5.0 / 6.0 },
                { (true, false), 1.0 / 4.0 },
                { (false, true), 1.0 / 2.0 },
                { (false, false), 0.0 },
            }
        ) { }
}
